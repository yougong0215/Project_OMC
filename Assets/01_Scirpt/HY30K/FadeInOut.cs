using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public int TimeToFade = 3;

    private void Update()
    {
        if (fadeIn == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut == true)
        {
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha -= TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }
}
