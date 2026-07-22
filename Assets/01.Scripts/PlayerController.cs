using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;

    public static PlayerController instance;
    Vector3 dir;

    bool isGround;
    public CoinManager cm;
    public GameManager game;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;

    [SerializeField][Range(0f, 1f)] float jumpSpeed;




    private Animator animator;
    int isRun;
    int isJump;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);


        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isRun=Animator.StringToHash("isRun");
        isJump = Animator.StringToHash("isJump");
    }
    void Update()
    {
        

        dir = Vector3.zero;
        if (Keyboard.current.aKey.isPressed)
            dir += Vector3.left;
        if (Keyboard.current.dKey.isPressed)
            dir += Vector3.right;

        GroundCheck();
        //Flip();

        if (Keyboard.current.spaceKey.isPressed)
        {
            Jump();
        }

        
    }
    private void FixedUpdate()
    {
       
        if (isGround)
        {
            if(dir.x!=0)
            {
                animator.SetBool(isRun, true);
                animator.SetBool(isJump, false);
            }
            else
            {

                animator.SetBool(isJump, false);
                animator.SetBool(isRun, false);
            }
            rb.linearVelocity = new Vector2(dir.x * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            float js = dir.x * moveSpeed;
            float newJp = Mathf.MoveTowards(rb.linearVelocity.x, js, moveSpeed * jumpSpeed * Time.fixedDeltaTime * 10f);
            rb.linearVelocity = new Vector2(newJp, rb.linearVelocity.y);
            animator.SetBool(isJump, true);
            animator.SetBool(isRun, false);
            

        }
    }
    #region
    //private void SetAnimation()
    //{
    //    if(isGround)
    //    {
    //        if(moveSpeed==0)
    //        {
    //            animator.Play("Player_Idle");
    //        }
    //        else
    //        {
    //            animator.SetBool("isRun",true);
    //        }
    //    }
    //    else
    //    {
    //        if(rb.linearVelocityY>0)
    //        {
    //            animator.SetBool("isJump",true);
    //        }
    //        else
    //        {
    //            animator = null;
    //        }
    //    }
    //}
    #endregion


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {

            cm.coinCount++;
            Debug.Log("먹음");
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

    

    void Jump()
    {
        if(isGround==false) return;
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGround = false;
            animator.SetBool(isJump, true);
            animator.SetBool(isRun, false);
        }
        
    }
    void GroundCheck()
    {
        
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.3f, -transform.up, 0.3f, groundLayer);

        isGround = hit.collider == null ? false : true;

    }

    public void RespawnMove()
    {

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

