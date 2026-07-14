using System;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;

    float dir;
    bool isGround;
    //bool isRightWall;
    //bool isLeftWall;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;

    [SerializeField][Range(0f, 1f)] float jumpSpeed;

    private int lifes = 3;

    public BoxCollider2D PlayerCollider;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            Heal();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {

        }
        if (collision.gameObject.tag == "Spine")
        {
            Hit();
        }
        if (collision.gameObject.tag == "Goal")
        {

        }
    }
    private void FixedUpdate()
    {
        if(isGround)
        {
            rb.linearVelocity = new Vector2(dir * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            float jp =dir * moveSpeed;
            float newJp = Mathf.MoveTowards(rb.linearVelocity.x, jp, moveSpeed * jumpSpeed * Time.fixedDeltaTime * 10f);
            rb.linearVelocity =new Vector2(newJp, rb.linearVelocity.y);
        }
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

    void Hit()
    {
        lifes -= 1;
        if(lifes==0)
        {
            DeadPlayer();
        }
    }
    void Heal()
    {
        lifes = Mathf.Min(3, lifes + 1);
        
    }
    void DeadPlayer()
    {
        col.enabled= false;

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position - new Vector3(0, 0.3f, 0), 0.3f);
    }


}

