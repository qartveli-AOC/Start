using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterSlay : MonoBehaviour
{

    public Transform transform_1;
    public Transform transform_2;
  
    void Update()
    {   if (Input.GetMouseButtonDown(0))
        {
            SlayBoss(transform_1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            SlayBoss(transform_2);
        }


    }

    private void SlayBoss(Transform trans)
    {
        trans.gameObject.SetActive(true);
        trans.SetAsLastSibling();
    }
}
