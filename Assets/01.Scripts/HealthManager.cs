using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int heart = 3;
    public Image[] hearts;
    public Sprite maxHeart;
    public Sprite emptyheart;

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyheart;
            
            
        }
        for(int i = 0; i < heart; i++)
        {
            hearts[i].sprite = maxHeart;
        }
        if(heart<=0)
        {
            heart = 0;
        }
    }






}
