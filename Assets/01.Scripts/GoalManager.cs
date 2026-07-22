using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    Collider2D col;
    public CoinManager cm;
    

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && cm.coinCount == 6)
        {
            if(SceneManager.GetActiveScene().name == "Stage2")
            {
                SceneManager.LoadScene("EndScenes");
            }

            else
            {
                SceneManager.LoadScene("Stage2");
                Debug.Log("∞Ò¿Œ");
            }
            



        }


    }
}
