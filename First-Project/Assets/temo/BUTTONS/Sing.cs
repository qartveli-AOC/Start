using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sing : MonoBehaviour
{
    
    public Image Button;

    public Sprite On_Music_Img;
    public Sprite Off_Music_Img;

    public bool Is_On_B;

    public AudioSource[] On_Music_Audio;

    private int clickCount = 0;

    public void Start()
    {
        foreach (var item in On_Music_Audio)
        {
            item.Play();
        }
    }
    public void Tog()
    {
        clickCount++;

        if (clickCount % 2 == 1)
            
        {
            On_Music_Audio[0].Pause();
            Button.sprite = Off_Music_Img;
        }
        else
        {
            On_Music_Audio[0].Play();
            Button.sprite = On_Music_Img;
        }
        
        
    }
}