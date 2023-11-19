using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[Serializable]
public class OutputContent
{
    [TextArea] public string text;
    public float waitTime;
    public float fadeTime; //알파 조정 시간
    public float duration;   //지속 시간

    public UnityEvent OnEvent;
}

public class TutorialManager : MonoBehaviour
{
    public List<OutputContent> DrawList;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = transform.Find("TextContent").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(TextDraw());
    }

    private IEnumerator TextDraw()
    {
        for (int i = 0; i < DrawList.Count; i++)
        {
            _text.text = DrawList[i].text;

            yield return new WaitForSeconds(DrawList[i].waitTime);

            _text.DOFade(1, DrawList[i].fadeTime);
            if (DrawList[i].OnEvent != null)
            {
                DrawList[i].OnEvent?.Invoke();
            }
            yield return new WaitForSeconds(DrawList[i].duration);
            _text.DOFade(0, DrawList[i].fadeTime);
            yield return new WaitForSeconds(DrawList[i].fadeTime);
        }
    }
}