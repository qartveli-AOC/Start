using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    
    public TextMeshProUGUI Number_Count;
    public Player_Stats play_stats;
    public GameObject Number_Count_gameobject;
    public Camera _camera;
    public Transform Transform_Canvas;





    void Start()
    {
        play_stats = FindObjectOfType<Player_Stats>();
        
    }


    void Update()
    {
       
    }
    public void NumberInstantiante()
    {
       

        GameObject number = Instantiate(Number_Count_gameobject, transform.position, Quaternion.identity);
        number.transform.SetParent(Transform_Canvas);
    }



    public void NumberCounter()
    {
        Number_Count.text = "+".ToString() + play_stats.Count.ToString();
    }



}
