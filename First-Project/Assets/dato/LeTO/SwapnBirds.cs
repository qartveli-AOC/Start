using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapnBirds: MonoBehaviour
{
    public GameObject spawn_obj;
    public Transform Canvas;

    public static bool Is_Birds = false;
    
    void Start()
    {
        float minDelay = 20;
        float MaxDelay = 60;
        InvokeRepeating("BirdSwapner", 0, Random.Range(minDelay, MaxDelay));
    }

    
    void Update()
    {
        
    }
    
    private void BirdSwapner()
    {   if(Is_Birds)
        {
            GameObject bird = Instantiate(spawn_obj, transform.position, Quaternion.identity);
            bird.transform.SetParent(Canvas);
        }
       
    }
}
