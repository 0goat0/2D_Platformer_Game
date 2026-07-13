using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Collider2D col;
    Vector2 dir;
    //public float moveSpeed;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] LayerMask groundLayer;

    bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider2D>();
    }
    private void Update()
    {
        dir = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            dir = Vector2.up;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            dir = Vector2.down;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            dir = Vector2.left;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            dir = Vector2.right;
        }
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 0.8f, groundLayer);

        isGround = hit.collider == null ? false : true;

    }
}

