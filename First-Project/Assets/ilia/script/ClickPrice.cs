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
    public static uint Daimond_Num;

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

    public Animator Animator_Hand;
    public AudioSource Hand_Audio_Source;
    public GameObject Hand_Particle;

    public AudioSource Click_Source;
    public AudioSource Halliluia_Song;
    public AudioClip[] Audio_Click;

    public GameObject leaves_gm;


    public Timer Timer_time;
    public GameObject Panel_noEnergy;



    private void Update()
    {
        Show_Score.text = Score.ToString();
        Daimond_Text.text = Daimond_Num.ToString();
        Power_Click_Text.text = Click_Count.ToString();

}
    public void Awake()
    {
       
        Score = PlayerPrefs.GetInt("coin", 0);
        Daimond_Num = (uint)PlayerPrefs.GetInt("SaveDiamond",0);
        GoHome.Season_Counter = PlayerPrefs.GetInt("SaveCountAnimation", 0);


        GoHome.CountIndex_Num = PlayerPrefs.GetInt("SaveWeather", 0);

        SpawnerLeaves.Is_Active_B = PlayerPrefs.GetInt("SaveBool", 1) == 1;

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
        if (GoHome.CountIndex_Num == 2)
        {
            SpawnerLeaves.Is_Active_B = true;
            leaves_gm.SetActive(true);
        }
        else
        {
            SpawnerLeaves.Is_Active_B = false;
        }

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
        Click_Source.clip = Audio_Click[3];
        Click_Source.Play();
        SwapMusicSingle.Instance.gameObject.SetActive(true);
        PlayerPrefs.SetInt("SaveDiamond",(int)Daimond_Num);
        PlayerPrefs.SetInt("SaveCountAnimation", GoHome.Season_Counter);
        PlayerPrefs.GetInt("SaveWeather",GoHome.CountIndex_Num);
        int isActiveInt = SpawnerLeaves.Is_Active_B ? 1 : 1;
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("coin", Score);
        ForSongExit2.IsOn_B_Soung = true;
        ForSongExit2.IsOn_B_Song = true;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("coin",Score);
        PlayerPrefs.SetInt("SaveDiamond", (int)Daimond_Num);
        PlayerPrefs.SetInt("SaveCountAnimation", GoHome.Season_Counter);
        PlayerPrefs.GetInt("SaveWeather", GoHome.CountIndex_Num);
        int isActiveInt = SpawnerLeaves.Is_Active_B ? 1 : 1;
        PlayerPrefs.Save();
    }

    public void Click()
    {   if(Timer_time.Curent_Time_Num > 0)
        {
            Trash_Generator_Cs.CreateTrash();
            Score += Click_Count;
            Click_Source.clip = Audio_Click[5];
            Click_Source.Play();

            if (Current_Level_Num <= Level_Full_Num)
            {
                Current_Level_Num++;
                Level_Slider.value = Current_Level_Num / Level_Full_Num;
            }
            if (Current_Level_Num >= Level_Full_Num)
            {
                Animator_Hand.SetTrigger("HandUp");
                Hand_Particle.SetActive(true);
                Halliluia_Song.Play();
                StartCoroutine(HendEffector());
                Current_Level_Num = 0;
                Daimond_Num += (uint)_diamond_x2_NUM;
                _diamond_x2_NUM = (_diamond_x2_NUM + 2) * 2;
            }
        }
         else
        {
            Panel_noEnergy.SetActive(true);
        }
       
    }

    public void One_Click_Shop()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Click_One_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= Click_One_Num;
                Click_One_Num *= 2;
                Click_One_Text.text = Click_One_Num.ToString();
                Click_Count += 1;
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
           
    }

    public void OneAuto()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= One_Auto_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= One_Auto_Num;
                One_Auto_Num *= 2;
                One_Auto_Text.text = One_Auto_Num.ToString();
                _auto_Count_Num++;
                StartCoroutine(Auto_Click());
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
            
            
    }
    void TenClick()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Ten_Click_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= Ten_Click_Num;
                Click_Count += 10;
                Ten_Click_Num *= 2;
                Ten_Click_Text.text = Ten_Click_Num.ToString();
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
           
    }
    void Auto10()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Auto_10_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= Auto_10_Num;
                _auto_Count_Num += 10;
                Auto_10_Num *= 2;
                Auto_10_Text.text = Auto_10_Num.ToString();
                Debug.Log("1");
                StartCoroutine(Auto_Click());
                Debug.Log("2");
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }

        else
        {
            Panel_noEnergy.SetActive(true);
        }
            
    }
    void OneHundredClick()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= OneHundred_Click_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= OneHundred_Click_Num;
                Click_Count += 100;
                OneHundred_Click_Num += ((OneHundred_Click_Num + 500) / 2);
                OneHundred_Click_Text.text = OneHundred_Click_Num.ToString();
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
            
    }
    void Auto100()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Auto_100_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= Auto_100_Num;
                _auto_Count_Num += 100;
                Auto_100_Num += ((Auto_100_Num + 2500) / 2);
                Auto_100_Text.text = Auto_100_Num.ToString();
                StartCoroutine(Auto_Click());
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
            
    }
    void HausentClick()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Hausent_Click_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= Hausent_Click_Num;
                Click_Count += 1000;
                Hausent_Click_Num += ((Hausent_Click_Num + 5000) / 2);
                Hausent_Click_Text.text = Hausent_Click_Num.ToString();

            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
            
       
    }
    void Diamond1sec()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Diamond_1sec_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= Diamond_1sec_Num;
                _diamond_Count += 1;
                Diamond_1sec_Num *= 2;
                Diamond_1sec_Text.text = Diamond_1sec_Num.ToString();
                StartCoroutine(Auto_Diamond());
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
            
            
    }
    void Diamond10sec()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Diamond_10sec_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Score -= Diamond_10sec_Num;
                _diamond_Count += 10;
                Diamond_10sec_Num += ((Diamond_10sec_Num + 5000) / 2);
                Diamond_10sec_Text.text = Diamond_10sec_Num.ToString();
                StartCoroutine(Auto_Diamond());
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
        }
            
        
           
        
    }
    void Diamond100()
    {
        if (Timer_time.Curent_Time_Num > 0)
        {
            if (Score >= Diamond_100_Num)
            {
                Click_Source.clip = Audio_Click[0];
                Click_Source.Play();
                Daimond_Num -= (uint)Diamond_100_Num;
                _diamond_Count += 100;
                Diamond_100_Num += Diamond_100_Num / 2;
                Diamond_100_Text.text = Diamond_100_Num.ToString();
                StartCoroutine(Auto_Diamond());
            }
            else
            {
                Click_Source.clip = Audio_Click[1];
                Click_Source.Play();
            }
        }
        else
        {
            Panel_noEnergy.SetActive(true);
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
                if (Timer_time.Curent_Time_Num > 0)
                {
                    Score += _auto_Count_Num;
                }
                   

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
                if (Timer_time.Curent_Time_Num > 0)
                {
                    Daimond_Num += (uint)_diamond_Count;
                }
                    

                }
            }
        
            
           
    }

    private IEnumerator HendEffector()
    {   
        yield return new WaitForSeconds(4);
        Hand_Particle.SetActive(false);
    }
    
   
}
