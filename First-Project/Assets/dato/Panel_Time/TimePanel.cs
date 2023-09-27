using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{   
    public Timer timer;
    public GameObject Panel_Obj_Timer;
    public Button Button_Exit_Panel;
    public GameObject Finger_Obj;

    public GameObject Finger_Home;
    public GameObject Panel_Home;

    public bool Is_job = true;

    private static bool _finger_b = true;
    private static bool _finger_Home_b = true;


    void Start()
    {
        Button_Exit_Panel.onClick.AddListener(ExitClick);
        Panel_Home.GetComponent<Image>().raycastTarget = false;
    }

    
    void Update()
    {
        CheckTimer();
    }

    private void CheckTimer()
    {
        if(timer.Curent_Time_Num <= 0)
        {   if(Is_job)
            {
                Is_job = false;
                if(_finger_b)
                {   _finger_b = false;
                    Finger_Obj.SetActive(true);
                }
               
                Panel_Obj_Timer.SetActive(true);
               
                
            }
           
        }

    }

    private void ExitClick()
    {
        Finger_Obj.SetActive(false);
        Panel_Obj_Timer.SetActive(false);
        if(_finger_Home_b)
        {
            _finger_Home_b = false;
            Finger_Home.SetActive(true);
            Panel_Home.GetComponent<Image>().raycastTarget = true;
        }
        
        

    }
}
