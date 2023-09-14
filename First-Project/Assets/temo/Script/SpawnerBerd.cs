using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBerd : MonoBehaviour
{
    public GameObject[] bird;
    public float Spawn_Time;
    void Start()
    {
        InvokeRepeating("SpawnerMetod",0, Spawn_Time);
    }

    
    void Update()
    {
       
    }


    void SpawnerMetod()
    {
        Instantiate(bird[Random.Range(0,bird.Length)], transform.position, Quaternion.identity);
    }
}
