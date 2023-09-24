using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForSongExit : MonoBehaviour
{   
    public Button Song_Button;
    public Button Soung_Button;
    public Button Exit_Button;
    public Button Setting_Button;

    public GameObject Panel_gm;

    public Image Song_Image;
    public Image Soung_Image;

    public Sprite[] Song_Sprite;
    public Sprite[] Soung_Sprite;

    public int Song_Currect_Num;
    public  int Sound_Currect_Num;

    public AudioSource Audi;
    public AudioSource Audio;

    public static bool  IsOn_B_Soung = true;
    public static bool  IsOn_B_Song = true;


    public GoHome GOO_Home;

    private void Awake()
    {
       
    }

    private   void Start()
     {
        Audi = SwapMusicSingle.Instance.Audio_Source;

        Song_Button.onClick.AddListener(SongClick);
        Soung_Button.onClick.AddListener(SoundClick);

        Exit_Button.onClick.AddListener(ExitClick);
        Setting_Button.onClick.AddListener(SettingClick);
    }

    
   

    public void SongClick()
    {
        Song_Image.sprite = Song_Sprite[Song_Currect_Num];
        Song_Currect_Num = (Song_Currect_Num +1) % Song_Sprite.Length;
        if (Song_Currect_Num == 1)
        {
            IsOn_B_Song = false;
        }
        else
        {
            IsOn_B_Song = true;
        }

        if (IsOn_B_Song)
        {  
            
                Audio.Play();
               
            

           
        }
        else
        {
            Audio.Pause();
           
        }
    }

    public void SoundClick()
    {
        Soung_Image.sprite = Soung_Sprite[Sound_Currect_Num];
        Sound_Currect_Num = (Sound_Currect_Num +1) % Soung_Sprite.Length;
        if( Sound_Currect_Num == 1)
        {
            IsOn_B_Soung = false;
        }
        else
        {
            IsOn_B_Soung = true;
        }

        if(IsOn_B_Soung)
        {
            Audi.Play();
        }
        else
        {
            Audi.Pause(); 
        }
    }

    public void SettingClick()
    {
        Panel_gm.SetActive(true);
        if(IsOn_B_Song)
        {
            GOO_Home.Song_Audio.clip = GOO_Home.Song_Clip_Audio[2];
            GOO_Home.Song_Audio.Play();
        }
       


    }

    public void ExitClick()
    {
        Panel_gm.SetActive(false);
        if (IsOn_B_Song)
        {
            GOO_Home.Song_Audio.clip = GOO_Home.Song_Clip_Audio[2];
            GOO_Home.Song_Audio.Play();
        }
    }
}
