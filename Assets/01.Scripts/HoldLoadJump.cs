using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldLoadJump : MonoBehaviour
{
    public float hold = 1f;
    public Image fillcircle;

    private float holdTimer = 0;
    private bool ishold = false;

    public static event Action OnHoldComplete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ishold)
        {
            holdTimer += Time.deltaTime;
            fillcircle.fillAmount = holdTimer / hold;
            if(holdTimer >= hold)
            {
                //OnHoldComplete.Invoke();
                RestHold();
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            ishold=true;
        }
        else if (context.canceled)
        {
            RestHold();
            ishold =false;
        }
    }

    private void RestHold()
    {
        ishold=false ;
        holdTimer = 0;
        fillcircle.fillAmount = 0;
    }
}
