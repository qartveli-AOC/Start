using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anim_Coin : MonoBehaviour
{
    public Image Image_Coin;
    public Sprite[] sprite_Coin;

    private int _currentSpriteIndex_Num = 0;
    public float Interval_Time_Coin_Num = 0.1f;

    void Start()
    {
        InvokeRepeating("NextSprite",0,Interval_Time_Coin_Num);
    }

   
    void Update()
    {
        
    }

    void NextSprite()
    {



        Image_Coin.sprite = sprite_Coin[_currentSpriteIndex_Num];


        _currentSpriteIndex_Num = (_currentSpriteIndex_Num + 1) % sprite_Coin.Length;
    }
}
