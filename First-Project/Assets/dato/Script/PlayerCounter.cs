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
    public Image image;
    public Sprite[] sprite;

   
     
     


    void Start()
    {       
        Garbige_Button.onClick.AddListener(SpawnPosition);
        Debug.Log("Inside");
        clickPrice = FindObjectOfType<ClickPrice>();
        
    }
    
  

    void SpawnPosition()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            Prefab_Text.text = clickPrice.Count.ToString();
            GameObject number = Instantiate(Number_Count_gameobject,hit.point, Quaternion.identity);
            number.transform.SetParent(Transform_Canvas);
        }
        image.sprite = sprite[Random.Range(0,sprite.Length)];

    }

}
