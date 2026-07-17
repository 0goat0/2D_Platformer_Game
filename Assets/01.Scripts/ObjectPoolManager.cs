using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;
    [SerializeField] List<GameObject> objList=new List<GameObject>();
    Dictionary<string,Queue<GameObject>>pool = new Dictionary<string,Queue<GameObject>>();

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
            pool[obj.name]=new Queue<GameObject>();

            GameObject parentPool=new GameObject(obj.name);
            parentPool.transform.SetParent(this.transform);

            for(int i = 0; i < poolCount; i++)
            {
                GameObject gameObject = Instantiate(obj,parentPool.transform);
                gameObject.SetActive(true);
                pool[obj.name].Enqueue(gameObject);
            }
        }
    }
    public GameObject GetObject(string name)
    {
        if (!pool.ContainsKey(name))
        {
            return null;

        }
        if(pool[name].Count > 0)
        {
            GameObject gameObject=pool[name].Dequeue();
            gameObject.SetActive (true);
            return gameObject;
        }
        else
        {
            GameObject gameObject=Instantiate(objList.Find(obj=>obj.name==name));
            return gameObject;
        }
    }

    void Update()
    {
        
    }
}
