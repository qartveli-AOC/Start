using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   



    public float Full_Time_Num;
    public float Curent_Time_Num;
    public float Timer_Num;
    public float One_Second_Num = 1;

    public Slider Time_Slider;
    public TextMeshProUGUI Timer_Num_Text;

    

    private void Update()
    {
        Timer_Num_Text.text = Curent_Time_Num.ToString();
        Timer_Num += Time.deltaTime;
        if(Timer_Num>=One_Second_Num && Curent_Time_Num != 0)
        {
            Timer_Num = 0;
            Curent_Time_Num--;
        }
        if(Curent_Time_Num == 0)
        {
            Timer_Num = 0;
            SceneManager.LoadScene(0);
        }

      
       

        Time_Slider.value = Curent_Time_Num / Full_Time_Num;

    }
}
