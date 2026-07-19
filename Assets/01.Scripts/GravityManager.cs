using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float gravityScale;
    public Transform[] center;
    public float gravity;

    float player;
    float distanc;
    float forceValue;

    Vector3 forceDirection;

    Rigidbody2D rb;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = rb.mass;
        
    }


    void Update()
    {
        for (int i = 0; i < center.Length; i++)
        {
            distanc = Vector3.Distance(center[i].position, transform.position);

            if (distanc > 0.1f)
            {
                float planetSize = center[i].localScale.x;
                forceValue = (gravity * planetSize) * (gravityScale * player) / (distanc * distanc);

                forceDirection = (center[i].position - transform.position).normalized;
                rb.AddForce(forceValue * forceDirection);
            }
        }
    }


}
