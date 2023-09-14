using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menai : MonoBehaviour
{
   


    public Sprite[] sprites; 
    

    public Image ImageComponent;
    private int _currentSpriteIndex_Num = 0;

    void Start()
    {
       
        InvokeRepeating("NextSprite", 0, 0.1f ); 
    }

    void NextSprite()
    {



        ImageComponent.sprite = sprites[_currentSpriteIndex_Num];


        _currentSpriteIndex_Num = (_currentSpriteIndex_Num + 1) % sprites.Length;
    }
}


