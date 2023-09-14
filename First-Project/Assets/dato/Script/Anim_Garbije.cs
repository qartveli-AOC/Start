using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anim_Garbije : MonoBehaviour
{
   


    public Sprite[] sprites; 
    

    public Image ImageComponent;
    private int _currentSpriteIndex_Num = 0;
    public float Interval_Time_Num = 0.1f;

    void Start()
    {
       
        InvokeRepeating("NextSprite", 0, Interval_Time_Num ); 
    }

    void NextSprite()
    {



        ImageComponent.sprite = sprites[_currentSpriteIndex_Num];


        _currentSpriteIndex_Num = (_currentSpriteIndex_Num + 1) % sprites.Length;
    }
}


