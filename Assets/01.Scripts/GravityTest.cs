using UnityEngine;

public class GravityTest : MonoBehaviour
{
    public float gravityScale = 1f;
    public Transform closestPlanet;
    public float G = 6.6f;

    [SerializeField] public LayerMask planetLayer;

    private Rigidbody2D rb;
    private float playerMass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMass = rb.mass;
    }
    private void FixedUpdate()
    {
        float maxGravityForce= -1f;
        Transform localClosestPlanet = null;

        Collider2D[] planets=Physics2D.OverlapCircleAll(transform.position,50f,planetLayer);

        for (int i = 0; i < planets.Length; i++)
        {
            Transform planetTransform = planets[i].transform;
            float distance = Vector3.Distance(planetTransform.position, transform.position);

            CircleCollider2D planetCollider = planets[i] as CircleCollider2D;
            float maxRange = planetCollider.radius * planetTransform.localScale.x;

            if (distance <= maxRange && distance > 0.1f)
            {
                float planetSize =planetTransform.localScale.x;
                float forceValue = (G * planetSize * gravityScale * playerMass) / (distance * distance);
                Vector3 forceDirection=(planetTransform.position-transform.position).normalized;

                rb.AddForce(forceDirection * forceValue);

                if(forceValue>maxGravityForce)
                {
                    maxGravityForce = forceValue;
                    localClosestPlanet=planetTransform;
                }


            }
        }
        closestPlanet = localClosestPlanet;

        if (closestPlanet != null)
        {
            Vector2 gravityDirection = (closestPlanet.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.down, gravityDirection);

            rb.MoveRotation(targetRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

