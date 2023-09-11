using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCountFly : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float Destroy_Time;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        _rb.AddForce(Vector3.up * _speed * Time.deltaTime );
        if(gameObject)
        {
            Destroy(gameObject, Destroy_Time);
        }
        
        
    }

   
}
