using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScaler : MonoBehaviour
{
    private Button _button_Scaler;
    private RectTransform _transform;
    void Start()
    {
        _transform = GetComponent<RectTransform>();
        _button_Scaler = GetComponent<Button>();
        _button_Scaler.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        _transform.localScale = new Vector2(1.1f, 1.1f);
        StartCoroutine(ITimeBacke());
    }

    IEnumerator ITimeBacke()
    {

        yield return new WaitForSeconds(0.1f);

        _transform.localScale = new Vector2(1f, 1f);
    }
}
