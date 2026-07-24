using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    [SerializeField] private SpriteRenderer sprite;

    public AudioClip jumpClip;
    public AudioClip hitClip;
    public AudioClip hitCoin;
    public AudioClip hitHeart;
    public AudioClip hitPlanetClip;

    private AudioSource audioSource;

    private Animator animator;
    int isRun;
    int isJump;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();

        isRun=Animator.StringToHash("isRun");
        isJump = Animator.StringToHash("isJump");
    }
    void Update()
    {
        

        dir = Vector3.zero;
        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("flipx=ture");
            dir += Vector3.left;
            sprite.flipX = true;
        }
            
        
        if (Keyboard.current.dKey.isPressed)
        {
            Debug.Log("flipx=false");
            dir += Vector3.right;
            sprite.flipX = false;
        }
            

        GroundCheck();


        
    }
    private void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            Jump();
        }


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
            //PlaySFX(jumpClip);

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
            PlaySFX(hitCoin,0.3f);
          
            
        }
        if (collision.gameObject.tag == "Heart")
        {
            if(HealthManager.heart<3)
            {
                HealthManager.heart++;
                Destroy(collision.gameObject);
                PlaySFX(hitHeart,0.3f);
                //Heal();
            }
            else
            {
                
            }
        }
        if(collision.gameObject.tag =="Spine")
        {
            PlaySFX(hitClip);
            HealthManager.heart=Mathf.Max(0,HealthManager.heart-1);
            if(HealthManager.heart <= 0)
            {
                
                GameManager.instance.Die();
                
            }
            else
            {

            }
        }
        if (collision.gameObject.tag == "Asteroid")
        {
            HealthManager.heart = Mathf.Max(0, HealthManager.heart - 1);
            if (HealthManager.heart <= 0)
            {
                GameManager.instance.Die();
                Destroy(collision.gameObject);
                //PlaySFX(hitClip);
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
            PlaySFX(jumpClip, 0.3f);
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

    public void PlaySFX(AudioClip audioClip,float volume=1f)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
   

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position - new Vector3(0, 0.3f, 0), 0.3f);
    }


}

