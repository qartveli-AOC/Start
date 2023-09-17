using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMyBirds: MonoBehaviour
{
    public GameObject gm_Birds;
    public Transform transform_Birds_Spavner;
    public Transform Ca_bojechka;
    void Start()
    {
        InvokeRepeating("SwapnOneBirds",0,1);
    }

   
    void Update()
    {
        
    }
    private void SwapnOneBirds()
    {
        GameObject gm = Instantiate(gm_Birds,transform_Birds_Spavner.position,Quaternion.identity);
        gm.transform.SetParent(Ca_bojechka);
    }
}
