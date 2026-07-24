using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    [SerializeField] List<GameObject> objList=new List<GameObject>();
    
    Dictionary<string,Queue<GameObject>>pools = new Dictionary<string,Queue<GameObject>>();

    int poolCount;
    private void Awake()
    {
        if(instance==null)
            instance = this;
        else
            Destroy(gameObject);
        
    }
    void Start()
    {
        poolCount = 10;

        foreach(GameObject obj in objList)
        {
            pools[obj.name]=new Queue<GameObject>();

            GameObject parentPool=new GameObject(obj.name);
            parentPool.transform.SetParent(this.transform);

            for(int i = 0; i < poolCount; i++)
            {
                GameObject gameObject = Instantiate(obj,parentPool.transform);
                gameObject.SetActive(false);
                pools[obj.name].Enqueue(gameObject);
            }
        }
    }
    public GameObject GetObject(string name)
    {
        if (!pools.ContainsKey(name))
        {
            return null;

        }
        if(pools[name].Count > 0)
        {
            GameObject gameObject=pools[name].Dequeue();
            gameObject.SetActive (true);
            return gameObject;
        }
        else
        {
            GameObject go=Instantiate(objList.Find(obj=>obj.name==name));
            return go;
        }
    }
    public void ReturnObject(string name,GameObject go)
    {
        if(!pools.ContainsKey(name))
        {
            Destroy(go);
            return;
        }
        go.SetActive(false);
        pools[name].Enqueue (go);
        
    }

    void Update()
    {
        
    }
}
