using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
