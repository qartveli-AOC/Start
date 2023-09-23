using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMusicSingle : MonoBehaviour
{   

    public static SwapMusicSingle Instance;


    public AudioClip[] audio_Clips;
    private int clipIndex = 0;
    public AudioSource Audio_Source;

    private void Start()
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


        Audio_Source = GetComponent<AudioSource>();

        
        if (Audio_Source == null)
        {
            Debug.LogError("Error");
        }
    }

    private void FixedUpdate()
    {
        if (audio_Clips == null || audio_Clips.Length == 0)
        {
            Debug.LogError("Error.");
            return;
        }


        if (!Audio_Source.isPlaying)
        {
            
            clipIndex = (clipIndex + 1) % audio_Clips.Length;

      
            Audio_Source.clip = audio_Clips[clipIndex];
            Audio_Source.Play();
        }
    }
}
