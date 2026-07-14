using UnityEngine;

public class Spine : MonoBehaviour
{
    

    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            Debug.Log("µ¥¹ÌÁö");
        }
    }


}
