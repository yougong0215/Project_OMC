using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    FadeInOut fade;
    void Start()
    {
        fade.GetComponent<FadeInOut>();
        fade.FadeOut();
    }
}
