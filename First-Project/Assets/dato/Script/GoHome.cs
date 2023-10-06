using System.Collections;
using System.Collections.Generic;
using YG;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoHome : MonoBehaviour
{
    public TextMeshProUGUI Text_Daimond_Home;
    public TextMeshProUGUI Price_Update_Text1;
    public TextMeshProUGUI Price_Update_Text2;
    public TextMeshProUGUI Price_Update_Text3;

    public int Price_Update_Num_1;
    public int Price_Update_Num_2;
    public int Price_Update_Num_3;


    public Button Button_Go_Home;
    public Button[] Button_Upgrade_Click;
    public Button Chest_Button;

    public Slider Slider_Upgrade_Answer;
    public Slider[] Slider_Upgrade_Click;

    public RectTransform[] Transform_Buttons;
    public RectTransform Chest_Button_Transform;

    public Image Upgrade_Img_1;
    public Image Upgrade_Img_2;
    public Image Upgrade_Img_3;

    public Sprite[] Sprite_img_1;
    public Sprite[] Sprite_img_2;
    public Sprite[] Sprite_img_3;
    public int _currentSpriteIndex_Num_1 = 0;
    public int _currentSpriteIndex_Num_2 = 0;
    public int _currentSpriteIndex_Num_3 = 0;

    public float Currect_Slider_Click_1;
    public float Fuul_Slider_Click_1;

    public float Currect_Slider_Click_2;
    public float Fuul_Slider_Click_2;

    public float Currect_Slider_Click_3;
    public float Fuul_Slider_Click_3;

    public float Currect_Slid;
    public float Full_Slid;


    public GameObject[] Particle_Objects;
    public   static int CountIndex_Num;


    public AudioSource Song_Audio;
    public AudioClip[] Song_Clip_Audio;

    public static int Season_Counter;

    public ForSongExit For_Song_Exit;
    public GameObject Particle;

    public GameObject[] Seasons;

    public ParticleSystem Smoke;
    public GameObject Little_fire;

    public  ForSongExit _forSongExit;

    public YandexGame yandexGame;

    public Button Reward_Button;
    private uint xUpper = 1;

    public void RewardCall()
    {        
        yandexGame._RewardedShow(1);        
    }

    public void RewardMoney()
    {
             
        ClickPrice.Daimond_Num +=((100+xUpper) * xUpper)-(xUpper*78);
        xUpper++;
    }
    
    private void Awake()
    {   
        Currect_Slid = PlayerPrefs.GetFloat("SaveSliderLid", 0);
        Currect_Slider_Click_1 = PlayerPrefs.GetFloat("sav10", 0);
        Currect_Slider_Click_2 = PlayerPrefs.GetFloat("sav11", 0);
        Currect_Slider_Click_3 = PlayerPrefs.GetFloat("sav12", 0);


        _currentSpriteIndex_Num_1 = PlayerPrefs.GetInt("SaveSprite100", 0);
        _currentSpriteIndex_Num_2 = PlayerPrefs.GetInt("SaveSprite200", 0);
        _currentSpriteIndex_Num_3 = PlayerPrefs.GetInt("SaveSprite300", 0);


        Price_Update_Num_1 = PlayerPrefs.GetInt("SaveDaimondPrice1", 50);
        Price_Update_Num_2 = PlayerPrefs.GetInt("SaveDaimondPrice2", 20);
        Price_Update_Num_3 = PlayerPrefs.GetInt("SaveDaimondPrice3", 10);

        ClickPrice.Daimond_Num = (uint)PlayerPrefs.GetInt("SaveDiamond", 0);

        Season_Counter = PlayerPrefs.GetInt("SaveCountAnimation",0);

        CountIndex_Num = PlayerPrefs.GetInt("SaveWeather",0);


        SpawnerLeaves.Is_Active_B = PlayerPrefs.GetInt("SaveBool", 1) == 1;


        Particle_Objects[CountIndex_Num].SetActive(true);
        if (CountIndex_Num == 1)
        {
            Smoke.Play();
        }

        else
        {
            Smoke.Stop();
        }

        if (CountIndex_Num == 3)
        {
            Little_fire.SetActive(true);
        }

        else
        {
            Little_fire.SetActive(false);
        }
         

        
        Seasons[CountIndex_Num].SetActive(true);

    }



    private void Start()

    {
       
   
        if(CountIndex_Num ==0)
        {
            Particle.SetActive(true);
        }
        else
        {
            Particle.SetActive(false);
        }

        
        
        


        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
        Slider_Upgrade_Click[0].value = Currect_Slider_Click_1 / Fuul_Slider_Click_1;
        Slider_Upgrade_Click[1].value = Currect_Slider_Click_2 / Fuul_Slider_Click_2;
        Slider_Upgrade_Click[2].value = Currect_Slider_Click_3 / Fuul_Slider_Click_3;

       





        Button_Go_Home.onClick.AddListener(GoHomeClick);
        Button_Upgrade_Click[0].onClick.AddListener(SliderAnswer1);
        Button_Upgrade_Click[1].onClick.AddListener(SliderAnswer2);
        Button_Upgrade_Click[2].onClick.AddListener(SliderAnswer3);
        Chest_Button.onClick.AddListener(ChectClick);
    }



  





    private void FixedUpdate()
    {
        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
        Slider_Upgrade_Click[0].value = Currect_Slider_Click_1 / Fuul_Slider_Click_1;
        Slider_Upgrade_Click[1].value = Currect_Slider_Click_2 / Fuul_Slider_Click_2;
        Slider_Upgrade_Click[2].value = Currect_Slider_Click_3 / Fuul_Slider_Click_3;


        
        Upgrade_Img_1.sprite = Sprite_img_1[_currentSpriteIndex_Num_1];
        Upgrade_Img_2.sprite = Sprite_img_2[_currentSpriteIndex_Num_2];
        Upgrade_Img_3.sprite = Sprite_img_3[_currentSpriteIndex_Num_3];



        Price_Update_Text1.text = Price_Update_Num_1.ToString();
        Price_Update_Text2.text = Price_Update_Num_2.ToString();
        Price_Update_Text3.text = Price_Update_Num_3.ToString();


        Text_Daimond_Home.text = ClickPrice.Daimond_Num.ToString();

        if (CountIndex_Num == 0)
        {
            Particle.SetActive(true);
        }

        if (CountIndex_Num == 3)
        {
            Little_fire.SetActive(true);
        }












    }
    private void OnApplicationQuit()
    {

        PlayerPrefs.SetFloat("SaveSliderLid", Currect_Slid);
        PlayerPrefs.SetFloat("sav10", Currect_Slider_Click_1);
        PlayerPrefs.SetFloat("sav11", Currect_Slider_Click_2);
        PlayerPrefs.SetFloat("sav12", Currect_Slider_Click_3);

        PlayerPrefs.SetInt("SaveSprite100", _currentSpriteIndex_Num_1);
        PlayerPrefs.SetInt("SaveSprite200", _currentSpriteIndex_Num_2);
        PlayerPrefs.SetInt("SaveSprite300", _currentSpriteIndex_Num_3);
        PlayerPrefs.Save();


        PlayerPrefs.SetInt("SaveDaimondPrice1", Price_Update_Num_1);
        PlayerPrefs.SetInt("SaveDaimondPrice2", Price_Update_Num_2);
        PlayerPrefs.SetInt("SaveDaimondPrice3", Price_Update_Num_3);
        PlayerPrefs.SetInt("SaveDiamond", (int)ClickPrice.Daimond_Num);

        PlayerPrefs.SetInt("SaveCountAnimation", Season_Counter);

        PlayerPrefs.SetInt("SaveWeather", CountIndex_Num);


        int isActiveInt = SpawnerLeaves.Is_Active_B ? 1 : 0;
        PlayerPrefs.SetInt("SaveBool", isActiveInt);

    }

    private void GoHomeClick()
    {   
        PlayerPrefs.SetFloat("SaveSliderLid", Currect_Slid);
        PlayerPrefs.SetFloat("sav10", Currect_Slider_Click_1);
        PlayerPrefs.SetFloat("sav11", Currect_Slider_Click_2);
        PlayerPrefs.SetFloat("sav12", Currect_Slider_Click_3);

        PlayerPrefs.SetInt("SaveSprite100", _currentSpriteIndex_Num_1);
        PlayerPrefs.SetInt("SaveSprite200", _currentSpriteIndex_Num_2);
        PlayerPrefs.SetInt("SaveSprite300", _currentSpriteIndex_Num_3);


        PlayerPrefs.SetInt("SaveDaimondPrice1", Price_Update_Num_1);
        PlayerPrefs.SetInt("SaveDaimondPrice2", Price_Update_Num_2);
        PlayerPrefs.SetInt("SaveDaimondPrice3", Price_Update_Num_3);

        PlayerPrefs.SetInt("SaveDiamond", (int)ClickPrice.Daimond_Num);
        PlayerPrefs.SetInt("SaveCountAnimation", Season_Counter);
        PlayerPrefs.SetInt("SaveWeather", CountIndex_Num);


        int isActiveInt = SpawnerLeaves.Is_Active_B ? 1 : 0; 
        PlayerPrefs.SetInt("SaveBool", isActiveInt);

        PlayerPrefs.Save();
        SwapMusicSingle.Instance.gameObject.SetActive(true);
        SwapMusicSingle.Instance.Audio_Source.enabled = true;
        ForSongExit.IsOn_B_Song  = true;
        ForSongExit.IsOn_B_Soung = true;

        Song_Audio.clip = Song_Clip_Audio[2];
        Song_Audio.Play();
        SceneManager.LoadScene(0);
        
      
        Transform_Buttons[3].localScale = new Vector3 (1.1f, 1.1f, 1.1f);
        StartCoroutine(ForButtonClicable());
    }

    private void SliderAnswer1()
    {
        Transform_Buttons[0].localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(ForButtonClicable());
        if (ClickPrice.Daimond_Num >= Price_Update_Num_1)
        { 
            if (Currect_Slid < Full_Slid)
            {
                if (Currect_Slider_Click_1 < Fuul_Slider_Click_1)
                {   if (ForSongExit.IsOn_B_Song)
                    {
                        Song_Audio.clip = Song_Clip_Audio[0];
                        Song_Audio.Play();
                    }
                        NextSprite1();
                        Currect_Slid++;
                        Season_Counter++;
                        SliderMassivClick();
                        Price_Update_Num_1 +=(Price_Update_Num_1+100)/2;
                    
                   

                }
                else
                {
                    if (ForSongExit.IsOn_B_Song)
                    {

                        Song_Audio.clip = Song_Clip_Audio[1];
                        Song_Audio.Play();
                    }
                }
            }
            else
            {
                if (ForSongExit.IsOn_B_Song)
                {
                    Song_Audio.clip = Song_Clip_Audio[1];
                    Song_Audio.Play();
                }
                    
            }

        }
        else
        {
            if (ForSongExit.IsOn_B_Song)
            {
                Song_Audio.clip = Song_Clip_Audio[1];
                Song_Audio.Play();
            }
               
        }

        if (Currect_Slid == Full_Slid)
        {
            Currect_Slid = 0;
            Currect_Slider_Click_1 = 0;
            Currect_Slider_Click_2 = 0;
            Currect_Slider_Click_3 = 0;
            Slider_Upgrade_Click[0].value = 0;

            Debug.Log("MENAI");
            Particle_Objects[CountIndex_Num].SetActive(false);
            Seasons[CountIndex_Num].SetActive(false);
            CountIndex_Num = (CountIndex_Num + 1) % Particle_Objects.Length;
            Particle_Objects[CountIndex_Num].SetActive(true);
            Seasons[CountIndex_Num].SetActive(true);

            if (CountIndex_Num == 0  )
            {
                Particle.SetActive(true);
            }
            else
            {
                Particle.SetActive(false);
            }


            if (CountIndex_Num == 3)
            {
                SpawnerLeaves.Is_Active_B = true;
                Little_fire.SetActive(true);

            }
            else
            {
                SpawnerLeaves.Is_Active_B = false;
                Little_fire.SetActive(false);
            }


            if (CountIndex_Num == 2)
            {
                SwapnBirds.Is_Birds = true;
            }
            else
            {
                SwapnBirds.Is_Birds = false;
            }
            if (CountIndex_Num == 1)
            {
                Smoke.Play();
            }

            else
            {
                Smoke.Stop();
            }

        }

        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
    }


    private void SliderAnswer2()
    {
        Transform_Buttons[1].localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(ForButtonClicable());
        if (ClickPrice.Daimond_Num >= Price_Update_Num_2)
        {
            if (Currect_Slid < Full_Slid)
            {
                if (Currect_Slider_Click_2 < Fuul_Slider_Click_2)
                {
                    if (ForSongExit.IsOn_B_Song)
                    {
                        Song_Audio.clip = Song_Clip_Audio[0];
                        Song_Audio.Play();
                    }
                        
                    NextSprite2();
                    Currect_Slid++;
                    SliderMassivClick2();
                    Price_Update_Num_2 += (Price_Update_Num_2 + 20)/2 ;
                    Season_Counter++;


                }
                else
                {
                    if (ForSongExit.IsOn_B_Song)
                    {
                        Song_Audio.clip = Song_Clip_Audio[1];
                        Song_Audio.Play();
                    }
                        
                }

            }
            else
            {
                if (ForSongExit.IsOn_B_Song)
                {
                    Song_Audio.clip = Song_Clip_Audio[1];
                    Song_Audio.Play();
                }
                   
            }

        }
        else
        {
            if (ForSongExit.IsOn_B_Song)
            {
                Song_Audio.clip = Song_Clip_Audio[1];
                Song_Audio.Play();
            }
                
        }
       
        if (Currect_Slid == Full_Slid)
        {
            Currect_Slid = 0;
            Currect_Slider_Click_1 = 0;
            Currect_Slider_Click_2 = 0;
            Currect_Slider_Click_3 = 0;
            Slider_Upgrade_Click[1].value = 0;

            Debug.Log("MENAI");
            Particle_Objects[CountIndex_Num].SetActive(false);
            Seasons[CountIndex_Num].SetActive(false);

            CountIndex_Num = (CountIndex_Num + 1) % Particle_Objects.Length;


            Particle_Objects[CountIndex_Num].SetActive(true);
            Seasons[CountIndex_Num].SetActive(true);
            if (CountIndex_Num == 0  )
            {
                Particle.SetActive(true);
            }
            else
            {
                Particle.SetActive(false);
            }
            if (CountIndex_Num == 3)
            {
                SpawnerLeaves.Is_Active_B = true;
                Little_fire.SetActive(true);
            }
            else
            {
                SpawnerLeaves.Is_Active_B = false;
                Little_fire.SetActive(false);
            }
            if (CountIndex_Num == 2)
            {
                SwapnBirds.Is_Birds = true;
            }
            else
            {
                SwapnBirds.Is_Birds = false;
            }
            if (CountIndex_Num == 1)
            {
                Smoke.Play();
            }

            else
            {
                Smoke.Stop();
            }
        }

        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
       
    }



    private void SliderAnswer3()
    {
        Transform_Buttons[2].localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(ForButtonClicable());
        if (ClickPrice.Daimond_Num >= Price_Update_Num_3)
        {


            if (Currect_Slid < Full_Slid)
            {
                if (Currect_Slider_Click_3 < Fuul_Slider_Click_3)
                {
                    if (ForSongExit.IsOn_B_Song)
                    {
                        Song_Audio.clip = Song_Clip_Audio[0];
                        Song_Audio.Play();
                    }
                       
                    NextSprite3();
                    Currect_Slid++;
                    Season_Counter++;
                    SliderMassivClick3();
                    Price_Update_Num_3 += (Price_Update_Num_3 + 10)/2;



                    
                }
                else
                {
                    if (ForSongExit.IsOn_B_Song)
                    {
                        Song_Audio.clip = Song_Clip_Audio[1];
                        Song_Audio.Play();
                    }
                       
                }

            }

            else
            {
                if (ForSongExit.IsOn_B_Song)
                {
                    Song_Audio.clip = Song_Clip_Audio[1];
                    Song_Audio.Play();
                }
                   
            }
           
        }
        else
        {
            if (ForSongExit.IsOn_B_Song)
            {
                Song_Audio.clip = Song_Clip_Audio[1];
                Song_Audio.Play();
            }
                
        }
     
        if (Currect_Slid == Full_Slid)
        {
            Currect_Slid = 0;
            Currect_Slider_Click_1 = 0;
            Currect_Slider_Click_2 = 0;
            Currect_Slider_Click_3 = 0;
            Slider_Upgrade_Click[2].value = 0;
            Debug.Log("MENAI");
            Particle_Objects[CountIndex_Num].SetActive(false);
            Seasons[CountIndex_Num].SetActive(false);

            CountIndex_Num = (CountIndex_Num + 1) % Particle_Objects.Length;


            Particle_Objects[CountIndex_Num].SetActive(true);
            Seasons[CountIndex_Num].SetActive(true);
            if (CountIndex_Num == 0 )
            {
                Particle.SetActive(true);
            }
            else
            {
                Particle.SetActive(false);
            }
            if (CountIndex_Num == 3)
            {
                SpawnerLeaves.Is_Active_B = true;
                Little_fire.SetActive(true);
            }
            else
            {
                SpawnerLeaves.Is_Active_B = false;
                Little_fire.SetActive(false);
            }
            if (CountIndex_Num == 2)
            {
                SwapnBirds.Is_Birds = true;
            }
            else
            {
                SwapnBirds.Is_Birds = false;
            }
            if (CountIndex_Num == 1)
            {
                Smoke.Play();
            }

            else
            {
                Smoke.Stop();
            }
        }

        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
       
    }

    private void SliderMassivClick()
    {   if(Currect_Slider_Click_1<Fuul_Slider_Click_1)
        {
            Currect_Slider_Click_1++;
            ClickPrice.Daimond_Num -= (uint)Price_Update_Num_1;
            Text_Daimond_Home.text = ClickPrice.Daimond_Num.ToString();
        }
        
        Slider_Upgrade_Click[0].value = Currect_Slider_Click_1 / Fuul_Slider_Click_1;
    }


    private void SliderMassivClick2()
    {   if(Currect_Slider_Click_2<Fuul_Slider_Click_2)
        {
            Currect_Slider_Click_2++;
            ClickPrice.Daimond_Num -= (uint)Price_Update_Num_2;
            Text_Daimond_Home.text = ClickPrice.Daimond_Num.ToString();
        }
        
        Slider_Upgrade_Click[1].value = Currect_Slider_Click_2 / Fuul_Slider_Click_2;
    }


    private void SliderMassivClick3()
    {   if(Currect_Slider_Click_3<Fuul_Slider_Click_3)
        {
            Currect_Slider_Click_3++;
            ClickPrice.Daimond_Num -= (uint)Price_Update_Num_3;
            Text_Daimond_Home.text = ClickPrice.Daimond_Num.ToString();
        }
        
        Slider_Upgrade_Click[2].value = Currect_Slider_Click_3 / Fuul_Slider_Click_3;
    }




    IEnumerator ForButtonClicable()
    {
        yield return new WaitForSeconds(0.1f);
        Transform_Buttons[0].localScale = new Vector3(1, 1, 1);
        Transform_Buttons[1].localScale = new Vector3(1, 1, 1);
        Transform_Buttons[2].localScale = new Vector3(1, 1, 1);
        Transform_Buttons[3].localScale = new Vector3(1, 1, 1);
        Chest_Button_Transform.localScale = new Vector3(1,1,1);
    }

    private void NextSprite1()
    {
        Upgrade_Img_1.sprite = Sprite_img_1[_currentSpriteIndex_Num_1];
       
        _currentSpriteIndex_Num_1 = (_currentSpriteIndex_Num_1 + 1) % Sprite_img_1.Length;
    }

    private void NextSprite2()
    {
        Upgrade_Img_2.sprite = Sprite_img_2[_currentSpriteIndex_Num_2];
       
        _currentSpriteIndex_Num_2 = (_currentSpriteIndex_Num_2 + 1) % Sprite_img_2.Length;
    }

    private void NextSprite3()
    {
        Upgrade_Img_3.sprite = Sprite_img_3[_currentSpriteIndex_Num_3];
        
        _currentSpriteIndex_Num_3 = (_currentSpriteIndex_Num_3 + 1) % Sprite_img_3.Length;
    }


    private void ChectClick()
    {
        Chest_Button_Transform.localScale = new Vector3(1.1f,1.1f,1.1f);
        StartCoroutine(ForButtonClicable());
        if(ForSongExit.IsOn_B_Song)
        {
            Song_Audio.clip = Song_Clip_Audio[3];
            Song_Audio.Play();
        }
        
    }


}
