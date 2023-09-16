using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoHome : MonoBehaviour
{
    public Button Button_Go_Home;
    public Button[] Button_Upgrade_Click;

    public Slider Slider_Upgrade_Answer;
    public Slider[] Slider_Upgrade_Click;
    public float Currect_Slider_Click_1;
    public float Fuul_Slider_Click_1;

    public float Currect_Slider_Click_2;
    public float Fuul_Slider_Click_2;

    public float Currect_Slider_Click_3;
    public float Fuul_Slider_Click_3;

    public float Currect_Slid;
    public float Full_Slid;
    
   private void Start()
    {
        
        Currect_Slid = 0;
        Button_Go_Home.onClick.AddListener(GoHomeClick);
        Button_Upgrade_Click[0].onClick.AddListener(SliderAnswer1);
        Button_Upgrade_Click[1].onClick.AddListener(SliderAnswer2);
        Button_Upgrade_Click[2].onClick.AddListener(SliderAnswer3);
    }

    private void FixedUpdate()
    {
        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
        Slider_Upgrade_Click[0].value = Currect_Slider_Click_1 / Fuul_Slider_Click_1;
        Slider_Upgrade_Click[1].value = Currect_Slider_Click_2 / Fuul_Slider_Click_2;
        Slider_Upgrade_Click[2].value = Currect_Slider_Click_3 / Fuul_Slider_Click_3;

    }


    private void GoHomeClick()
    {
        SceneManager.LoadScene(1);
    }
   
    private void SliderAnswer1()
    {   if(Currect_Slid<Full_Slid)
        {   if(Currect_Slider_Click_1<Fuul_Slider_Click_1)
            {
                Currect_Slid++;
            }
            
        }
        SliderMassivClick();
        if (Currect_Slid == Full_Slid)
        {
            Currect_Slid = 0;
            Currect_Slider_Click_1 = 0;
            Currect_Slider_Click_2 = 0;
            Currect_Slider_Click_3 = 0;
            Slider_Upgrade_Click[0].value = 0;
        }
        
        Slider_Upgrade_Answer.value = Currect_Slid/Full_Slid;
        

    }


    private void SliderAnswer2()
    {
        if (Currect_Slid < Full_Slid)
        {   if(Currect_Slider_Click_2<Fuul_Slider_Click_2)
            {
                Currect_Slid++;
            }
            
        }
        SliderMassivClick2();
        if (Currect_Slid == Full_Slid)
        {
            Currect_Slid = 0;
            Currect_Slider_Click_1 = 0;
            Currect_Slider_Click_2 = 0;
            Currect_Slider_Click_3 = 0;
            Slider_Upgrade_Click[1].value = 0;
        }

        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
       
    }



    private void SliderAnswer3()
    {
        if (Currect_Slid < Full_Slid)
        {   if(Currect_Slider_Click_3<Fuul_Slider_Click_3)
            {
                Currect_Slid++;
            }
            
        }
        SliderMassivClick3();
        if (Currect_Slid == Full_Slid)
        {
            Currect_Slid = 0;
            Currect_Slider_Click_1 = 0;
            Currect_Slider_Click_2 = 0;
            Currect_Slider_Click_3 = 0;
            Slider_Upgrade_Click[2].value = 0;
        }

        Slider_Upgrade_Answer.value = Currect_Slid / Full_Slid;
       
    }

    private void SliderMassivClick()
    {   if(Currect_Slider_Click_1<Fuul_Slider_Click_1)
        {
            Currect_Slider_Click_1++;
        }
        
        Slider_Upgrade_Click[0].value = Currect_Slider_Click_1 / Fuul_Slider_Click_1;
    }


    private void SliderMassivClick2()
    {   if(Currect_Slider_Click_2<Fuul_Slider_Click_2)
        {
            Currect_Slider_Click_2++;
        }
        
        Slider_Upgrade_Click[1].value = Currect_Slider_Click_2 / Fuul_Slider_Click_2;
    }


    private void SliderMassivClick3()
    {   if(Currect_Slider_Click_3<Fuul_Slider_Click_3)
        {
            Currect_Slider_Click_3++;
        }
        
        Slider_Upgrade_Click[2].value = Currect_Slider_Click_3 / Fuul_Slider_Click_3;
    }







}
