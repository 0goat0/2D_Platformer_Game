using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    float speed = 10f;
    Rigidbody2D rb;

    float lifeTime;
    float timer;

    void Start()
    {
        lifeTime = 15f;

        rb=GetComponent<Rigidbody2D>();
        //GameObject astero= ObjectPoolManager.instance.GetObject("Asteroid");
    }
    private void OnEnable()
    {
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;
        Vector2 move = new Vector2(-1f, -1f).normalized;

        rb.linearVelocity = move * speed;
        
        if(timer>lifeTime)
        {
            ObjectPoolManager.instance.ReturnObject("Asteroid", this.gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Planet")
        {
            Debug.Log("Planet_collision");
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("player_collision");
            Destroy(gameObject);
        }
    }
    // void Die()
    //{
    //    ReturnPool();
    //}

    //void ReturnPool()
    //{
    //    ObjectPoolManager.instance.ReturnObject("Asteroid",gameObject);
    //}
}
