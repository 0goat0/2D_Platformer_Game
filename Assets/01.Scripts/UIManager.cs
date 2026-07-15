using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image heartPrefab;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    private List<Image> herts =new List<Image>();

    public void SetMaxHearts(int maxHearts)
    {
        foreach(Image heart in herts)
        {
            Destroy(heart.gameObject);
        }
        herts.Clear();

        for(int i = 0; i< maxHearts; i++)
        {
            Image newHeart =Instantiate(heartPrefab,transform);
            newHeart.sprite=fullHeartSprite;
            newHeart.color=Color.white;
            herts.Add(newHeart);
        }
    }

    public void UpdateHearts(int currentHeart)
    {
        for(int i = 0;i< herts.Count;i++)
        {
            if(i< currentHeart)
            {
                herts[i].sprite = fullHeartSprite;
                herts[i].color = Color.white;
            }
            else
            {
                herts[i].sprite=emptyHeartSprite;
                herts[i].color = Color.black;
            }
        }

        
    }




}
