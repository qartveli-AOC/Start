using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGoHome : MonoBehaviour
{
    public static SingleGoHome Instance;
   
    void Start()
    {
        
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    void Update()
    {
        
    }
}
