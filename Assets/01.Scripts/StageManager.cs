using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] Transform player;
    [SerializeField] Transform respawnPoint;

    Rigidbody2D playerRb;

    int deadCount;

    private void Awake()
    {
        if(instance == null)
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
        playerRb = GetComponent<Rigidbody2D>();
        deadCount = 0;
        UIManager.instance.ChangeDeadCountText(deadCount);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
