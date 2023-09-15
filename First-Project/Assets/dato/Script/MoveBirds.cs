using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBirds : MonoBehaviour
{
    private Rigidbody rb;
    public float Force_Speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.right * Time.deltaTime * Force_Speed);
    }
}
