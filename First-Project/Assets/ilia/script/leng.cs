using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leng : MonoBehaviour
{

    public static int Leng_Scene_Num;


    void Start()
    {
        Leng_Scene_Num = PlayerPrefs.GetInt("len", 0);              
    }

    
    void Update()
    {
        Debug.Log(Leng_Scene_Num + "dddddddddddddddddd");
    }


   public void English()
    {
        SceneManager.LoadScene(1);
        Leng_Scene_Num = 1;
        PlayerPrefs.SetInt("len", Leng_Scene_Num);
    }
    public void Russian() 
    {
        SceneManager.LoadScene(0);
        Leng_Scene_Num = 0;
        PlayerPrefs.SetInt("len", Leng_Scene_Num);
    }
}
