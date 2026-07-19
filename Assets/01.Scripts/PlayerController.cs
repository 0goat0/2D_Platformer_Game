using System;
using Unity.Mathematics.Geometry;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;

    public static PlayerController2 instance;
    float dir;
    bool isGround;
    public CoinManager cm;
    public GameManager game;

    //public Heart ht;
    //bool isRightWall;
    //bool isLeftWall;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;

    [SerializeField][Range(0f, 1f)] float jumpSpeed;

    Rigidbody2D playerRb;

    //public HealthManager maxHeart;
    private void Awake()
    {
        if(instance==null)
            instance = this;
        else
        {
            Destroy(instance);
            return;
        }
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //currentHeart = maxHeart;
        //heartUI.SetMaxHearts(maxHeart);
        playerRb = GetComponent<Rigidbody2D>();
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {

            cm.coinCount++;
            Debug.Log("∏‘¿Ω");
            Destroy(collision.gameObject);
          
            
        }
        if (collision.gameObject.tag == "Heart")
        {
            if(HealthManager.heart<3)
            {
                HealthManager.heart++;
                Destroy(collision.gameObject);
                //Heal();
            }
            else
            {
                
            }
        }
        if(collision.gameObject.tag =="Spine")
        {
            HealthManager.heart=Mathf.Max(0,HealthManager.heart-1);
            if(HealthManager.heart <= 0)
            {
                GameManager.instance.Die();
            }
            else
            {

            }
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
            float js =dir * moveSpeed;
            float newJp = Mathf.MoveTowards(rb.linearVelocity.x, js, moveSpeed * jumpSpeed * Time.fixedDeltaTime * 10f);
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
    public void RespawnMove()
    {
        dir = 0;
        if(rb!=null)
        {
            rb.linearVelocity=Vector2.zero;
        }    
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position - new Vector3(0, 0.3f, 0), 0.3f);
    }


}

