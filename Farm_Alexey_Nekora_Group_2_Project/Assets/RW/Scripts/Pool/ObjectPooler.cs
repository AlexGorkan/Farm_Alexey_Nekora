using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable] //serialiacia classa nizhe
public class ObjectPoolItem  //class
{
    public GameObject pooledObject; // prefab ovci
    public int poolSize; //razmer poola
    public bool willGrow; //chackbox


}

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler objectPooler; //singleton object
    [SerializeField] private List<ObjectPoolItem> itemsToPool; // pool s poolami
    [SerializeField] private List<GameObject> pooledObjects;



    private void Awake()
    {
        objectPooler = this; //ssilka sam na sebia (odin unikalnij ekzemplar classa)
        pooledObjects = new List<GameObject>();
    }

    void Start()
    {
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.poolSize; i++)
            {
                pooledObjects.Add(Instantiate(item.pooledObject)); //sozdaem object i pomesharm v list
                pooledObjects[i].transform.SetParent(transform); // 
                pooledObjects[i].SetActive(false); // deactivacia objecta

            }
        }

        
    }

    public GameObject GetPooledObject(string tag) // metod vozvrashaet neaktivnij objekt s opredelennim tag
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) // esli ne activen
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.pooledObject.tag == tag)
            {
                if (item.willGrow) //galochka DA na rost poola
                {
                    GameObject obj = Instantiate(item.pooledObject);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    obj.transform.SetParent(transform);
                    return obj;

                }

            }
            
        }
        
        return null; //vzvrashaem nichego
    }

}
