using UnityEngine;

public class GoalObject : MonoBehaviour
{

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("∞Ò¿Œ");
        }
    }

}
