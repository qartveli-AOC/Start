using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;


public class Player_Stats : MonoBehaviour
{
    public GameObject Number_Count_gameobject;
    public Transform Transform_Canvas;
TextMeshProUGUI _text;
 


    public void NumberInstantiante22()
    {


        GameObject number = Instantiate(Number_Count_gameobject, transform.position, Quaternion.identity);
        number.transform.SetParent(Transform_Canvas);
    }

}
