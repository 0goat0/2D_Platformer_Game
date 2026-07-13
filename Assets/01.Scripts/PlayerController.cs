using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;

    float dir;
    bool isGround;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] LayerMask groundLayer;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private void Update()
    {

        dir = 0;
        if (Keyboard.current.aKey.isPressed)
            dir += -1;
        if (Keyboard.current.dKey.isPressed)
            dir += 1;

        GroundCheck();

        if (Keyboard.current.spaceKey.isPressed)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity=new Vector2(dir*moveSpeed,rb.linearVelocity.y);
    }

    void Jump()
    {
        if(isGround==false)
            return;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        isGround = false;
    }
    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 0.3f, groundLayer);

        isGround = hit.collider == null ? false : true;

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position - new Vector3(0, 0.3f, 0), 0.3f);
    //}
}

