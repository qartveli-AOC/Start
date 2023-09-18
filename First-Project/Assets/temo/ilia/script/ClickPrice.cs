using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ClickPrice : MonoBehaviour
{
    private bool _check_Turn_B=false;

    private int _auto_Click_Num = 0;
    public int Score;
    public int Count;
    public int Click_Cost = 10;
    public int One_Auto_Cost = 50;
    public float Current_Level_Num;
    public float Level_Full_Num;
    public static int Daimond_Num;

    public Button Home_Button;
    public Button Auto_Button;
    public Button Click_Button;
    public Button Ten_Click_Button;
    public Button Dable_Click_Button;
    public Button Diamond_10sec_Button;
    public Button Diamond_1sec_Button;
    
    public Button Count_Button;
    
    public TextMeshProUGUI Click_Price;
    public TextMeshProUGUI One_Auto_Price;
    public TextMeshProUGUI Daimond_Text;
   
    public TextMeshProUGUI Show_Score;

    public AudioSource Coin_Sound;    

    public Slider Level_Slider;

    public GameObject Spawn_Birds;

    public Transform Birds_Spawn_Position;
    public Transform Canvas_posI;

    public  Trash_Generator Trash_Generator_Cs;
    public MusicManager musicManager;

    private void Awake()
    {
        
        Score = PlayerPrefs.GetInt("coin", 0);
        Daimond_Num = PlayerPrefs.GetInt("diamond", 0);
        Show_Score.text = Score.ToString();
        Daimond_Text.text = Daimond_Num.ToString();
        One_Auto_Price.text = One_Auto_Cost.ToString() + "  Auto click 1/s";
        Click_Price.text = Click_Cost.ToString() + "   One click";

    }
    void Start()
    {      
        Count = 1;
        Home_Button.onClick.AddListener(Go_Home);
        Auto_Button.onClick.AddListener(One_Auto_Shop);
        Click_Button.onClick.AddListener(One_Click_Shop);
        Level_Slider.value = 0;
        Count_Button.onClick.AddListener(Click);
        PlayerPrefs.GetInt("rep", 0);
    }
   void Go_Home()
    {
        musicManager.repeatCount++;
        PlayerPrefs.SetInt("rep", musicManager.repeatCount);
        musicManager.Check();
        SceneManager.LoadScene(0);

    }
   

    public  void Click()
    {      
        Trash_Generator_Cs.CreateTrash();
        Score += Count;
        Show_Score.text = Score.ToString();       
        Coin_Sound.Play();
       
        if (Current_Level_Num<=Level_Full_Num)
        {
            Current_Level_Num++;
            Level_Slider.value = Current_Level_Num/Level_Full_Num;
        } if (Current_Level_Num>=Level_Full_Num)
        {
            SpawnBirds();
            Current_Level_Num =0;
            Daimond_Num += 1;
            Daimond_Text.text = Daimond_Num.ToString();
        }
       

    }
    private void SpawnBirds()
    {
        GameObject gm = Instantiate(Spawn_Birds, Birds_Spawn_Position.position, Quaternion.identity);
        gm.transform.SetParent(Canvas_posI);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("coin",Score); 
        PlayerPrefs.SetInt("diamond",Daimond_Num);
        PlayerPrefs.Save();
    }

    public void One_Auto_Shop()
    {        
        if (Score >= One_Auto_Cost)
        {           
            Score -= One_Auto_Cost;
            One_Auto_Cost *= 2;           
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
            Score -= Click_Cost;
            Click_Cost *= 2;
            Show_Score.text = Score.ToString();
            Click_Price.text = Click_Cost.ToString() + "   One click";
            Count += 1;

        }
           
            
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
