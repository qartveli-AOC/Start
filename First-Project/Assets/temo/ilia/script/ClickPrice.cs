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

    private bool _check_Turn_B=false;

    private int _auto_Click_Num = 0;
    public int Score;
    public int Count;
    public int Click_Cost = 10;
    public int One_Auto_Cost = 50;
    public float Level_Upgrade_Click_Num;
    public float Level_Full_Num;

    public Button Auto_Button;
    public Button Click_Button;
    
    public Button Count_Button;
    
    public TextMeshProUGUI Click_Price;
    public TextMeshProUGUI One_Auto_Price;
   
    public TextMeshProUGUI Show_Score;

    public AudioSource Coin_Sound;    

    public Slider Level_Slider;

    private Color _originalColor;
    private Color _targetColor;

    private void Awake()
    {
        
        Score = PlayerPrefs.GetInt("surim", 0);
        Show_Score.text = Score.ToString();
    }
    void Start()
    {
        _originalColor = Level_Slider.colors.normalColor;
        _targetColor = _originalColor;

        Count = 1;     
       
        Auto_Button.onClick.AddListener(One_Auto_Shop);
        Click_Button.onClick.AddListener(One_Click_Shop);
       
        Count_Button.onClick.AddListener(Click);     
    }
   
   

    public  void Click()
    {      
        Score += Count;
        Show_Score.text = Score.ToString();
        Coin_Sound.Play();
        
        if (Level_Upgrade_Click_Num<Level_Full_Num)
        {
            Level_Upgrade_Click_Num++;
            Level_Slider.value = Level_Upgrade_Click_Num/Level_Full_Num;
        }
        Color newColor = Color.Lerp(Color.red, Color.green, Level_Slider.value);
        Level_Slider.fillRect.GetComponent<Image>().color = newColor;

    }   


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("surim",Score);
        PlayerPrefs.Save();
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
            _auto_Click_Num++;
            if(!_check_Turn_B)
            {               
                _check_Turn_B = true;
                AutoClickOn();
            }
                  
        }
            
    }

    private void AutoClickOn()
    {
            StartCoroutine(I_Auto_Click());
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
            yield return new WaitForSeconds(1);
            Score += _auto_Click_Num;
            Show_Score.text = Score.ToString();
        }
        
    }
        
    
   
}