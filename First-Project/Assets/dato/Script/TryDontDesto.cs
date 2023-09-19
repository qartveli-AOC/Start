using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryDontDesto : MonoBehaviour
{
    public static TryDontDesto Instance;
    public ParticleSystem particleSystems;
    void Start()
        
    {
        particleSystems = GetComponent<ParticleSystem>();
        particleSystems.Play();
        
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        
    }
}
