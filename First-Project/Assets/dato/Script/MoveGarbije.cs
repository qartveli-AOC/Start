using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveGarbije : MonoBehaviour
{
    public Button Button_Garbije_Click;
    public RectTransform Garbije_Transform_Pos;

    public float Vector_Position_Num;
    public float Wait_Time;

    private void Start()
    {
        Button_Garbije_Click.onClick.AddListener(GarbijeScale);
    }






    public void GarbijeScale()
    {
        Garbije_Transform_Pos.localScale = new Vector3(Vector_Position_Num, Vector_Position_Num, Vector_Position_Num);
        StartCoroutine(ClickGargije());
    }



    IEnumerator ClickGargije()
    {
        yield return new WaitForSeconds(Wait_Time);
        Garbije_Transform_Pos.localScale = new Vector3(1,1,1);
    }
}
