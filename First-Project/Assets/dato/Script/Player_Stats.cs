using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;


public class Player_Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int Count = 1;
    public int Score = 0;

    
    void Start()
    {
      
    }

   
    void Update()
    {
        
    }


    public void ScoreCount()
    {
        Score += Count;
        _text.text = Score.ToString();
    }

    public void ScoreCountX2()
    {
        Count = 2;

      
    }

}
