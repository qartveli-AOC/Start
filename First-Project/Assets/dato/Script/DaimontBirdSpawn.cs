using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaimontBirdSpawn : MonoBehaviour
{

    public GameObject[] Spawn_Birds;
    public Transform Birds_Spawn_Position;
    public Transform Canvas_posI;
    
     private void Start()
    {
        InvokeRepeating("SpanwBirls",0,1);
    }

    
     private void Update()
    {
        
    }

    private void SpanwBirls()
    {
        GameObject gm = Instantiate(Spawn_Birds[Random.Range(0,Spawn_Birds.Length)],Birds_Spawn_Position.position,Quaternion.identity);
        gm.transform.SetParent(Canvas_posI);
    }
}
