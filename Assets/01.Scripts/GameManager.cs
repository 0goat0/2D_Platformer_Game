using UnityEngine;




public class GameManager : MonoBehaviour
{
    Rigidbody2D rb;
    public static GameManager instance;
    public CoinManager cm;
    Vector2 startPos;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(instance);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (PlayerController.instance != null)
        {
            startPos = PlayerController.instance.transform.position;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region
    //public void GameStart()
    //{
    //    state = GameState.Playing;
    //    Time.timeScale = 1;
    //}
    //public void GameOver()
    //{
    //    Debug.Log("게임오버");
    //    state= GameState.GameOver;
    //}
    //public void GamePause()
    //{
    //    state= GameState.Pause;
    //    Time.timeScale = 0;    // 시간클래스에서 timeScale 속도를 0으로
    //                           // timeScale 2이면 x2
    //}
    //void Respawn()
    //{
    //    transform.position = startPos;
    //}
    #endregion
    public void Die()
    {
        Respawn();
    }
    public void Respawn()
    {
        HealthManager.heart = 3;

        if (PlayerController.instance != null)
        {
            PlayerController.instance.transform.position = startPos;
            PlayerController.instance.RespawnMove();
        }
        
    }
}
