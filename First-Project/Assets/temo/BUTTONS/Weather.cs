using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weather : MonoBehaviour
{
  
    public Image Button;

    public Sprite[] MusicImages;
    public AudioSource[] MusicTracks;

    private int currentTrackIndex = 0;

    public void Start()
    {

        if (MusicTracks.Length > 0 && MusicImages.Length > 1)
        {

            PlayCurrentTrack();
        }
    }

    public void Tog()
    {

        currentTrackIndex = (currentTrackIndex + 1) % MusicTracks.Length;


        PlayCurrentTrack();


        Button.sprite = MusicImages[currentTrackIndex];
    }


    private void PlayCurrentTrack()
    {

        foreach (var track in MusicTracks)
        {
            track.Stop();
        }


        MusicTracks[currentTrackIndex].Play();
    }
}

