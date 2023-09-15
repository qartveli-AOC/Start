using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    public ClickPrice clickPrice;
    public GameObject Number_Count_gameobject;
    public Camera _camera;

    public Transform Transform_Canvas;
    public Transform Spwner_Coin_Tr;
    
    public TextMeshProUGUI Prefab_Text;

    public Button Garbige_Button;

    
   

   
     
     


    void Start()
    {       
        Garbige_Button.onClick.AddListener(SpawnPosition);
        
        clickPrice = FindObjectOfType<ClickPrice>();
        
    }
    
  

    void SpawnPosition()
    {
       
        
            Prefab_Text.text = clickPrice.Count.ToString();            
            GameObject number = Instantiate(Number_Count_gameobject, Spwner_Coin_Tr.position, Quaternion.identity);
            number.transform.SetParent(Transform_Canvas);
        
       

    }

}
