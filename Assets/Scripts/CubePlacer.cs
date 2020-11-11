using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubePlacer 
{
   // static List<Transform> objects;
    static List<GameObject> gameObjects;
    public static void placeShape(Vector3 position, Transform transform)
    {
        //Transform newTransform = GameObject.Instantiate(transform, position, Quaternion.identity);

        GameObject cube = ObjectPool.sharedInstance.getPooledObject();
        if (cube != null)
        {
            cube.transform.position = position;
            cube.transform.rotation = transform.rotation;
            cube.SetActive(true);
        }

        cube.transform.position = position + new Vector3(0f, 0.5f, 0f);

       // newTransform.transform.position = position + new Vector3(0f, 0.5f, 0f);

        //if (objects == null)
        //{
        //    objects = new List<Transform>();
        //}
        //objects.Add(newTransform);
        if (gameObjects == null)
        {
            gameObjects = new List<GameObject>();
        }
        gameObjects.Add(cube);
    }

    public static void removeObject(Vector3 position)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].transform.position == position + new Vector3(0f, 0.5f, 0f))
            {
                //GameObject.Destroy(objects[i].gameObject);
                //objects.RemoveAt(i);
                gameObjects[i].SetActive(false);
                gameObjects.RemoveAt(i);
            }
        }
    }
}
