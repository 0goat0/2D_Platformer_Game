using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;
    public GameObject door;
    
    
    void Start()
    {
        
    }

    private void Update()
    {
        coinText.text = ": "+coinCount.ToString();

        if(coinCount==2)
        {
            Destroy(door);
        }
    }

}
