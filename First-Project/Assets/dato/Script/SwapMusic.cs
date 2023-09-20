using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMusic : MonoBehaviour
{
    public AudioClip[] audio_Clips;
    private int clipIndex = 0;
    private AudioSource _audio_Source;

    private void Start()
    {
        _audio_Source = GetComponent<AudioSource>();

        
        if (_audio_Source == null)
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


        if (!_audio_Source.isPlaying)
        {
            
            clipIndex = (clipIndex + 1) % audio_Clips.Length;

      
            _audio_Source.clip = audio_Clips[clipIndex];
            _audio_Source.Play();
        }
    }
}
