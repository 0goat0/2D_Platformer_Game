using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float gravityScale;
    public Transform[] center;
    public Transform closestPlanet;
    float maxGravityForce;
    public float gravity;
    public float G;

    float player;
    float distance;
    float forceValue;

    Vector3 forceDirection;

    Rigidbody2D rb;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = rb.mass;
        forceValue = G * (gravityScale * player) / (distance);

        
    }
    private void FixedUpdate()
    {
        maxGravityForce = -1f;
        for (int i = 0; i < center.Length; i++)
        {
            float distance = Vector3.Distance(center[i].position, transform.position);

            if (distance > 0.1f)
            {
                float planetSize = center[i].localScale.x;
                forceValue = (gravity * planetSize) * (gravityScale * player) / (distance * distance*2f);

                forceDirection = (center[i].position - transform.position).normalized;
                rb.AddForce(forceValue * forceDirection);

                if(forceValue>maxGravityForce)
                {
                    maxGravityForce = forceValue;
                    closestPlanet= center[i];
                }
                


            }
            

        }
        if (closestPlanet != null)
        {
            Vector2 gravityDirection = (closestPlanet.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.down, gravityDirection);

            rb.MoveRotation(targetRotation);
        }

    }
    void Update()
    {
        
    }




}
