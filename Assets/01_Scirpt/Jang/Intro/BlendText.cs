using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlendText : MonoBehaviour
{
    [SerializeField] private float speed;

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        float Alpha = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        Color textColor = text.color;
        textColor.a = Alpha;
        text.color = textColor;
    }
}
