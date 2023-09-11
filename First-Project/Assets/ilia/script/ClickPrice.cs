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

        Click_Price.text = Click_Cost.ToString()+"   One click";
        One_Auto_Price.text = One_Auto_Cost.ToString()+"  Auto click 1/s";
    }
  
  public  void Click()
    {
        Debug.Log(Score);
        Score += Count;
        Show_Score.text = Score.ToString();
        Show_Count.text = Score.ToString();

    }
   public void One_Auto_Shop()
    {
        Debug.Log("OKrrrr");
        if (Score >= One_Auto_Cost)
        {
            One_Auto_Price.text = One_Auto_Cost.ToString();
            Score -= One_Auto_Cost;
            One_Auto_Cost *= 2;
        }
            
    }
    public void One_Click_Shop()
    {
        Debug.Log("OK");
        if (Score >= Click_Cost)
        {
            Click_Price.text = Click_Cost.ToString();
            Score -= Click_Cost;
            Click_Cost *= 2;
        }
           
            
    }
    public void Chest()
    {
        Debug.Log("OK");
        Chest_Open.Play("chest_Open");
    }
      
        
    
   
}
