using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectPoolerSimple : MonoBehaviour
{
    public static ObjectPoolerSimple objectPooler; //singleton object
    [SerializeField] private GameObject pooledObject; // prefab ovci
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private int poolSize; //razmer pp
    [SerializeField] private bool willGrow;


    private void Awake()
    {
        objectPooler = this; //ssilka sam na sebia (odin unikalnij ekzemplar classa)
        pooledObjects = new List<GameObject>();
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            pooledObjects.Add(Instantiate(pooledObject)); //sozdaem object i pomesharm v list
            pooledObjects[i].transform.SetParent(transform); // 
            pooledObjects[i].SetActive(false); // deactivacia objecta

        }
    }

    public GameObject GetPooledObject() // metod vozvrashaet neaktivnij objekt
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) // esli ne active
            {
                return pooledObjects[i];
            }
        }

        if (willGrow) //galochka DA na rost poola
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(transform);
            return obj;
                       
        }
        return null; //vzvrashaem nichego
    }

}
