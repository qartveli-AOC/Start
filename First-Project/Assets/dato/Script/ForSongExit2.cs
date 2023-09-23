using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForSongExit2 : MonoBehaviour
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
    public int Sound_Currect_Num;


    public GameObject Audi;
    public GameObject Audio;

    public bool IsOn_B_Soung;
    public bool IsOn_B_Song;


    public ClickPrice CLica_Pricee;


    private void Awake()
    {
        Audi = GameObject.Find("BackGroundMusic");
    }

    private void Start()
    {
        

        Song_Button.onClick.AddListener(SongClick);
        Soung_Button.onClick.AddListener(SoundClick);

        Exit_Button.onClick.AddListener(ExitClick);
        Setting_Button.onClick.AddListener(SettingClick);
    }




    public void SongClick()
    {
        Song_Image.sprite = Song_Sprite[Song_Currect_Num];
        Song_Currect_Num = (Song_Currect_Num + 1) % Song_Sprite.Length;
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
            CLica_Pricee.Click_Source.clip = CLica_Pricee.Audio_Click[4];
            CLica_Pricee.Click_Source.Play();
            Audio.SetActive(true);



        }
        else
        {
            CLica_Pricee.Click_Source.clip = CLica_Pricee.Audio_Click[4];
            CLica_Pricee.Click_Source.Play();
            Audio.SetActive(false);
        }
    }

    public void SoundClick()
    {
        Soung_Image.sprite = Soung_Sprite[Sound_Currect_Num];
        Sound_Currect_Num = (Sound_Currect_Num + 1) % Soung_Sprite.Length;
        if (Sound_Currect_Num == 1)
        {
            IsOn_B_Soung = false;
        }
        else
        {
            IsOn_B_Soung = true;
        }

        if (IsOn_B_Soung)
        {
            Audi.SetActive(true);
            CLica_Pricee.Click_Source.clip = CLica_Pricee.Audio_Click[4];
            CLica_Pricee.Click_Source.Play();
        }
        else
        {
            CLica_Pricee.Click_Source.clip = CLica_Pricee.Audio_Click[4];
            CLica_Pricee.Click_Source.Play();
            Audi.SetActive(false);
        }
    }

    public void SettingClick()
    {
        Panel_gm.SetActive(true);
        CLica_Pricee.Click_Source.clip = CLica_Pricee.Audio_Click[4];
        CLica_Pricee.Click_Source.Play();


    }

    public void ExitClick()
    {
        CLica_Pricee.Click_Source.clip = CLica_Pricee.Audio_Click[4];
        CLica_Pricee.Click_Source.Play();
        Panel_gm.SetActive(false);
    }
}
