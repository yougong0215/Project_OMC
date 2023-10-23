using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Camera _cam;
    private Vector3 vec;
    

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _input.OnMovement += Movement;
        _cam= Camera.main;
        
    }


    public void Movement(Vector2 dir)
    {
        Debug.LogWarning("여서 FSM Move 변경");
        
        transform.position += vec * 5 * Time.deltaTime;
        
        if (dir == Vector2.zero)
        {
            if(Mathf.Abs(vec.x) > 0.01f)
                vec.x = Mathf.Abs(vec.x) - (0.1f * Time.deltaTime);
            
            if(Mathf.Abs(vec.y) > 0.01f)
                vec.y = Mathf.Abs(vec.y) - (0.1f * Time.deltaTime);
            
            if(Mathf.Abs(vec.z) > 0.01f)
                vec.z = Mathf.Abs(vec.z) - (0.1f * Time.deltaTime);
            return;
        }
        
        vec = new Vector3(0, 0, 0);
        if (dir.y >= 1)
            vec += _cam.transform.forward;
        else if (dir.y <= -1)
            vec += -_cam.transform.forward;

        if (dir.x >= 1)
            vec += _cam.transform.right;
        else if (dir.x <= -1)
            vec += -_cam.transform.right;
        vec.y = 0;
        transform.rotation = Quaternion.LookRotation(vec);
        print(vec);
        
    }
    
    
}
