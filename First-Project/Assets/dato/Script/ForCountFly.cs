using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForCountFly : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float Destroy_Time;
    public ClickPrice click;
    public TextMeshProUGUI Count_Power_Text;
    void Start()
    {
       click = FindAnyObjectByType<ClickPrice>();
        _rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        _rb.AddForce(Vector3.up * _speed * Time.deltaTime );
        if(gameObject)
        {
            Destroy(gameObject, Destroy_Time);
        }
        Count_Power_Text.text = click.Click_Count.ToString();

    }

   
}
