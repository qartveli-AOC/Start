using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ClickPrice : MonoBehaviour
{
    public Animator Chest_Open;

    private bool _auto_Click_Off_B =false;

    private int _auto_Click_Num = 0;
    public int Score;
    public int Count;
    public int Click_Cost = 10;
    public int One_Auto_Cost = 50;

    public Button Auto_Button;
    public Button Click_Button;
    public Button Chest_Button;
    public Button Count_Button;
    
    public TextMeshProUGUI Click_Price;
    public TextMeshProUGUI One_Auto_Price;
    public TextMeshProUGUI Show_Count;
    public TextMeshProUGUI Show_Score;
        
    void Start()
    {
       Score = 0;
       Count = 1;     
       
        Auto_Button.onClick.AddListener(One_Auto_Shop);
        Click_Button.onClick.AddListener(One_Click_Shop);
        Chest_Button.onClick.AddListener(Chest);
        Count_Button.onClick.AddListener(Click);     
    }
  
  public  void Click()
    {      
        Score += Count;
        Show_Score.text = Score.ToString();
        Show_Count.text = Score.ToString();

    }

   public void One_Auto_Shop()
    {        
        if (Score >= One_Auto_Cost)
        {
            One_Auto_Price.text = One_Auto_Cost.ToString() + "  Auto click 1/s"; 
            Score -= One_Auto_Cost;
            One_Auto_Cost *= 2;
            Show_Score.text = Score.ToString();
            One_Auto_Price.text = One_Auto_Cost.ToString() + "  Auto click 1/s";
            _auto_Click_Off_B = true;
            AutoClickOn();           
        }
            
    }

    private void AutoClickOn()
    {
        if(_auto_Click_Off_B)
            {
            _auto_Click_Num++;
            StartCoroutine(I_Auto_Click());
            }
    }

    public void One_Click_Shop()
    {
        if (Score >= Click_Cost)
        {
            Click_Price.text = Click_Cost.ToString() + "   One click";
            Score -= Click_Cost;
            Click_Cost *= 2;
            Show_Score.text = Score.ToString();
            Click_Price.text = Click_Cost.ToString() + "   One click";
            Count += 1;
        }
           
            
    }

    public void Chest()
    {
        Chest_Open.Play("chest_Open");
    }

 private IEnumerator I_Auto_Click()
    {
        while (true)
        {
            Score += _auto_Click_Num;
            Show_Score.text = Score.ToString();
            yield return new WaitForSeconds(1);
        }
        
    }
        
    
   
}