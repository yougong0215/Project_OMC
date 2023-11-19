using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
    private Transform rectSize;
    Camera cam;

    void Start()
    {
        rectSize = transform.GetChild(0).GetComponent<Transform>();
        cam = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(cam.transform);
    }

    public void SetHpBar(float cur, float max)
    {
        Debug.Log($"scale {cur / max}");
        rectSize.transform.localScale = new Vector3(cur / max, 1, 1);
    }
}