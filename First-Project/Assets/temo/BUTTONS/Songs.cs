using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    public int repeatCount = 0;
    public Button bt;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomSong();
        
    }

    void PlayRandomSong()
    {
        int randomIndex = Random.Range(0, songs.Length);
        audioSource.clip = songs[1];
        audioSource.Play();
    }
  
    void Update()
    {

       
        if (repeatCount >= 4)
            {
                PlayRandomSong();
                repeatCount = 0;
          
        }
        
    }
}