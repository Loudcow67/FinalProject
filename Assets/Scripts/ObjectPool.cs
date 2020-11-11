using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<GameObject> pooledObject;
    public GameObject objectBeingPooled;
    public int poolTotal;

    private void Awake()
    {
        sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObject = new List<GameObject>();
        for (int i = 0; i < poolTotal; i++)
        {
            GameObject cube = (GameObject)Instantiate(objectBeingPooled);
            cube.SetActive(false);
            pooledObject.Add(cube);
        }
    }

    public GameObject getPooledObject()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }
        return null;
    }
}
