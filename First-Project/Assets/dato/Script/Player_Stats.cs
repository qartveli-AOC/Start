using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;


public class Player_Stats : MonoBehaviour
{
    public GameObject Number_Count_gameobject;
    public Transform Transform_Canvas;

    [SerializeField] private TextMeshProUGUI _text;
    public int Count = 1;
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


    public void NumberInstantiante22()
    {


        GameObject number = Instantiate(Number_Count_gameobject, transform.position, Quaternion.identity);
        number.transform.SetParent(Transform_Canvas);
    }

}
