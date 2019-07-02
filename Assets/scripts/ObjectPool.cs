using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool current;
    public GameObject objectForPool;
    public int poolAmmount = 20;
    public bool growth = true;

    List<GameObject> objectsForPool;

    void Awake()
    {
        current = this;    
    }

    // Use this for initialization
    void Start ()
    {
        objectsForPool = new List<GameObject>();

        for (int i = 0; i < poolAmmount; i++)
        {
            GameObject obj = (GameObject) Instantiate(objectForPool);
            obj.SetActive(false);
            objectsForPool.Add(obj);
        }
	}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < objectsForPool.Count; i++)
        {
            if (!objectsForPool[i].activeInHierarchy)
            {
                return objectsForPool[i];
            }
        }
        if (growth)
        {
            GameObject obj = Instantiate(objectForPool);            
            objectsForPool.Add(obj);
            return obj;
        }
        return null;
    }
}
