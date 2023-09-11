using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI time_Text;
    
    private Image _timerBar;

    public float full_Time ;
    private float _timeLine;
    private int _time_Number;
    void Start()
    {
        _timerBar = GetComponent<Image>();
        _timeLine = full_Time;
        _time_Number = (int)_timeLine;
    }

    void Update()
    {
        if(_timeLine > 0)
        {
            _timeLine -= Time.deltaTime;
            _time_Number = (int)_timeLine;
            _timerBar.fillAmount = _timeLine / full_Time;
            time_Text.text = _time_Number.ToString();
        }
     
    }
}
