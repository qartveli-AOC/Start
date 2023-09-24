using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class MoveLeaves : MonoBehaviour
{
    public Rigidbody rb;
    public Image Image_Leaves;
    public Sprite[] Sprite_Leaves;
    public float Max_Speed;
    public float Min_Speed;

   
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Image_Leaves = GetComponent<Image>();
        Sprite spr = Sprite_Leaves[Random.Range(0, Sprite_Leaves.Length)];
        Image_Leaves.sprite = spr;
        Destroy(gameObject,5f);
    }

    
    void Update()
    {
        rb.AddForce(Vector3.left * Time.deltaTime * Random.Range(Min_Speed,Max_Speed));
       
       
    }
}
