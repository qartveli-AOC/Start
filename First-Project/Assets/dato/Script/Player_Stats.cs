using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    //public TextMeshPro _textMeshPro;
    public int Score = 0;
    
    void Start()
    {
    //    _textMeshPro = GameObject.Find("Count").GetComponent<TextMeshPro>();
    }

   
    void Update()
    {
        
    }


    public void ScoreCount()
    {
        Score++;
    //  _textMeshPro.text =  Score++.ToString();
    }
}
