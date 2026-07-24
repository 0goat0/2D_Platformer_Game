using UnityEngine;
using System.Collections.Generic;

public class G<T> : MonoBehaviour where T : Component
{
    [SerializeField] T objects;
    Queue<T> pool = new Queue<T>();

    void Start()
    {
        for(int i=0; i<5; i++)
        {
            T obj = Instantiate(objects) as T;
            pool.Enqueue(obj);
        }
    }
    public T GetObject()
    {
        T obj=pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }

}
