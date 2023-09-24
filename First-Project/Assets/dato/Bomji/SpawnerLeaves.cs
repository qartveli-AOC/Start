using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLeaves : MonoBehaviour
{
    public GameObject Leaves_gm;
    public Transform Canvas;
    public float Euler_Rotation_Z_Min;
    public float Euler_Rotation_Z_Max;
    public float Max_delay_Num;
    public float Min_delay_Num;
    void Start()
    {   
        InvokeRepeating("Sozidatel",0,Random.Range(Min_delay_Num,Max_delay_Num));
    }

    
    void Update()
    {
        
    }
    private void Sozidatel()
    {   
        GameObject gm = Instantiate(Leaves_gm, transform.position,Quaternion.Euler(0 ,0,
            Random.Range(Euler_Rotation_Z_Min,Euler_Rotation_Z_Max)));
        gm.transform.SetParent(Canvas);

    }
}
