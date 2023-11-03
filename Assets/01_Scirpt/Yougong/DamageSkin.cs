using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSkin : MonoBehaviour
{
    private Camera cam;
    

    public Camera Cam
    {
        get
        {
            if (cam == null)
            {
                cam = Camera.main;
            }

            return cam;
        }
    }

    private void OnEnable()
    {
        Destroy(gameObject, 0.8f);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(-Cam.transform.position);
    }
}
