using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    public ClickPrice clickPrice;
    public GameObject Number_Count_gameobject;
    public Camera _camera;
    public Transform Transform_Canvas;
    
    public TextMeshProUGUI Prefab_Text;

    public Button Garbige_Button;

   

    void Start()
    {       
        Garbige_Button.onClick.AddListener(NumberInstantiante);
        Debug.Log("Inside");
        clickPrice = FindObjectOfType<ClickPrice>();
        
    }
    
    void NumberInstantiante()
    {
        Prefab_Text.text = clickPrice.Count.ToString();
        GameObject number = Instantiate(Number_Count_gameobject, transform.position, Quaternion.identity);
        number.transform.SetParent(Transform_Canvas);

    }

}
