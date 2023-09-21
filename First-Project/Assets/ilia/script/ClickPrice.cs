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
    private bool _coin_IfAuto_Work_B=false;
    private bool _diamond_IfAuto_Work_B=false;

    private int _auto_Count_Num = 0;
    public int Click_Count;
    private int _diamond_x2_NUM=1;
    private int _diamond_Count;
    public int Score;
    public static int Daimond_Num;

    public int Click_One_Num = 10;
    public int One_Auto_Num = 50;
    public int Ten_Click_Num = 500;
    public int Auto_10_Num = 1000;
    public int OneHundred_Click_Num = 1500;
    public int Auto_100_Num = 5000;
    public int Hausent_Click_Num = 100000;
    public int Diamond_1sec_Num = 1000;
    public int Diamond_10sec_Num = 5000;
    public int Diamond_100_Num = 300000;

    public float Current_Level_Num;
    public float Level_Full_Num;
    
    public Button Home_Button;
    public Button Click_Button;
    public Button Auto_Button;
    public Button Ten_Click_Button;
    public Button Auto_10_Button;
    public Button OneHundred_Click_Button;
    public Button Auto_100_Button;    
    public Button Hausent_Click_Button;
    public Button Diamond_1sec_Button;
    public Button Diamond_10sec_Button;
    public Button Diamond_100_Diamond_Button;   
    public Button Count_Button;
    
    public TextMeshProUGUI Click_One_Text;
    public TextMeshProUGUI One_Auto_Text;
    public TextMeshProUGUI Ten_Click_Text;
    public TextMeshProUGUI Auto_10_Text;
    public TextMeshProUGUI OneHundred_Click_Text;
    public TextMeshProUGUI Auto_100_Text;
    public TextMeshProUGUI Hausent_Click_Text;
    public TextMeshProUGUI Diamond_1sec_Text;
    public TextMeshProUGUI Diamond_10sec_Text;
    public TextMeshProUGUI Diamond_100_Text;
    public TextMeshProUGUI Daimond_Text;
    public TextMeshProUGUI Show_Score;
    public TextMeshProUGUI Power_Click_Text;

    public AudioSource Coin_Sound;    

    public Slider Level_Slider;

    public Transform Canvas_posI;

    public  Trash_Generator Trash_Generator_Cs;

    public GameObject[] Sam_Postav;


    private void Update()
    {
        Show_Score.text = Score.ToString();
        Daimond_Text.text = Daimond_Num.ToString();
        Power_Click_Text.text = Click_Count.ToString();
}
    public void Awake()
    {
       
        Score = PlayerPrefs.GetInt("coin", 0);
       
        Daimond_Text.text = Daimond_Num.ToString();

        One_Auto_Text.text = One_Auto_Num.ToString();
        Click_One_Text.text = Click_One_Num.ToString();
        Ten_Click_Text.text = Ten_Click_Num.ToString();
        Auto_10_Text.text = Auto_10_Num.ToString();
        OneHundred_Click_Text.text = OneHundred_Click_Num.ToString() ;
        Auto_100_Text.text = Auto_100_Num.ToString();
        Hausent_Click_Text.text = Hausent_Click_Num.ToString();
        Diamond_1sec_Text.text= Diamond_1sec_Num.ToString();
        Diamond_10sec_Text.text = Diamond_10sec_Num.ToString();
        Diamond_100_Text.text = Diamond_100_Num.ToString();
        Sam_Postav[GoHome.CountIndex_Num].SetActive(true);
    }
    void Start()
    {
        Level_Slider.value = 0;
        Click_Count = 1;

        Home_Button.onClick.AddListener(Go_Home);
        Auto_Button.onClick.AddListener(OneAuto);
        Click_Button.onClick.AddListener(One_Click_Shop);
        Count_Button.onClick.AddListener(Click);
        Ten_Click_Button.onClick.AddListener(TenClick);
        Auto_10_Button.onClick.AddListener(Auto10);
        OneHundred_Click_Button.onClick.AddListener(OneHundredClick);
        Auto_100_Button.onClick.AddListener(Auto100);
        Hausent_Click_Button.onClick.AddListener(HausentClick);
        Diamond_1sec_Button.onClick.AddListener(Diamond1sec);
        Diamond_10sec_Button.onClick.AddListener(Diamond10sec);
        Diamond_100_Diamond_Button.onClick.AddListener(Diamond100);

    }
   void Go_Home()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("coin", Score);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("coin",Score); 
        
        PlayerPrefs.Save();
    }

    public void Click()
    {
        Trash_Generator_Cs.CreateTrash();
        Score += Click_Count;
        Coin_Sound.Play();

        if (Current_Level_Num <= Level_Full_Num)
        {
            Current_Level_Num++;
            Level_Slider.value = Current_Level_Num / Level_Full_Num;
        }
        if (Current_Level_Num >= Level_Full_Num)
        {
            
            Current_Level_Num = 0;
            Daimond_Num += _diamond_x2_NUM;           
            _diamond_x2_NUM = (_diamond_x2_NUM+2)*2 ;            
        }
    }

    public void One_Click_Shop()
    {
        if (Score >= Click_One_Num)
        {
            Score -= Click_One_Num;
            Click_One_Num *= 2;
            Click_One_Text.text = Click_One_Num.ToString();
            Click_Count += 1;
        }
    }

    public void OneAuto()
    {        
        if (Score >= One_Auto_Num)
        {           
            Score -= One_Auto_Num;
            One_Auto_Num *= 2;           
            One_Auto_Text.text = One_Auto_Num.ToString();
            _auto_Count_Num++;
                StartCoroutine(Auto_Click());                                 
        }
            
    }
    void TenClick()
    {
        if(Score >=Ten_Click_Num)
        {
            Score -= Ten_Click_Num;
            Click_Count += 10;
            Ten_Click_Num *= 2;
            Ten_Click_Text.text = Ten_Click_Num.ToString();
        }
    }
    void Auto10()
    {
        if(Score >=Auto_10_Num)
        {
            Score -= Auto_10_Num;
            _auto_Count_Num += 10;
            Auto_10_Num *= 2;
            Auto_10_Text.text = Auto_10_Num.ToString();
            Debug.Log("1");
            StartCoroutine(Auto_Click());
            Debug.Log("2");
        }
    }
    void OneHundredClick()
    {
        if(Score>=OneHundred_Click_Num)
        {
            Score -= OneHundred_Click_Num;
            Click_Count += 100;
            OneHundred_Click_Num += ((OneHundred_Click_Num+500) / 2) ;
            OneHundred_Click_Text.text = OneHundred_Click_Num.ToString();
        }
    }
    void Auto100()
    {
        if(Score>=Auto_100_Num)
        {
            Score -= Auto_100_Num;
            _auto_Count_Num += 100;
            Auto_100_Num += ((Auto_100_Num + 2500) / 2);
            Auto_100_Text.text = Auto_100_Num.ToString();           
                StartCoroutine(Auto_Click());
        }
    }
    void HausentClick()
    {
        if(Score >= Hausent_Click_Num)
        {
            Score -= Hausent_Click_Num;
            Click_Count += 1000;
            Hausent_Click_Num += ((Hausent_Click_Num +5000) / 2);
            Hausent_Click_Text.text = Hausent_Click_Num.ToString() ;
        }
    }
    void Diamond1sec()
    {
        if(Score >= Diamond_1sec_Num)
        {
            Score -= Diamond_1sec_Num;
            _diamond_Count += 1;
            Diamond_1sec_Num *= 2;
            Diamond_1sec_Text.text = Diamond_1sec_Num.ToString();
            StartCoroutine(Auto_Diamond());
        }
    }
    void Diamond10sec()
    {
        if(Score >=Diamond_10sec_Num)
        {
            Score -= Diamond_10sec_Num;
            _diamond_Count += 10;
            Diamond_10sec_Num += ((Diamond_10sec_Num+5000)/2);
            Diamond_10sec_Text.text = Diamond_10sec_Num.ToString();
            StartCoroutine(Auto_Diamond());
        }
    }
    void Diamond100()
    {
        if(Score >= Diamond_100_Num)
        {
            Daimond_Num -= Diamond_100_Num;
            _diamond_Count += 100;
            Diamond_100_Num += Diamond_100_Num/2;
            Diamond_100_Text.text = Diamond_100_Num.ToString();
            StartCoroutine(Auto_Diamond());
        }
    }

   
 private IEnumerator Auto_Click()
    {
        if (!_coin_IfAuto_Work_B)
        {
            _coin_IfAuto_Work_B = true;
            while (true)
            {               
                yield return new WaitForSeconds(1);
                Score += _auto_Count_Num;              

            }
        }
    }
private IEnumerator Auto_Diamond()
    {
        if (!_diamond_IfAuto_Work_B)
        {
            _diamond_IfAuto_Work_B = true;
            while (true)
            {
 
                yield return new WaitForSeconds(1);
                Daimond_Num += _diamond_Count;

            }
        }
           
    }
    
   
}
