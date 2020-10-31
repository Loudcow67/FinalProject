using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubePlacer 
{
    static List<Transform> objects;
    public static void placeShape(Vector3 position, Transform transform)
    {
        Transform newTransform = GameObject.Instantiate(transform, position, Quaternion.identity);

        newTransform.transform.position = position + new Vector3(0f, 1f, 0f);

        if (objects == null)
        {
            objects = new List<Transform>();
        }
        objects.Add(newTransform);
    }

    public static void removeObject(Vector3 position)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].position == position)
            {
                GameObject.Destroy(objects[i].gameObject);
                objects.RemoveAt(i);
            }
        }
    }
}
