using UnityEngine;
using UnityEngine.InputSystem;

public class Spine : Obstacle
{
    Rigidbody2D rb;
    Collider2D col;

    public int hit = 1;

    private int playerCurrentHeart;
    public HealthManager heartUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {

        }
    }



}
