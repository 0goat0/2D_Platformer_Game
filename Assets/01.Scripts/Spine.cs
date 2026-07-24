using UnityEngine;
using UnityEngine.InputSystem;

public class Spine : Obstacle
{
    Rigidbody2D rb;
    Collider2D col;

    public int hit = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        
    }

}
