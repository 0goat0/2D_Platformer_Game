using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinText;
    public GameObject door;
    private bool doorDestroyed;

    private void Update()
    {
        coinText.text = ": " + coinCount.ToString();
        if(coinCount==6&&!doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
    //private void FindCoinText()
    //{
    //    coinText = FindObjectOfType<TextMeshProUGUI>();
    //}

}
