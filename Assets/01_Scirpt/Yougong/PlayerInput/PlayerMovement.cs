using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private Camera _cam;
    
    

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _input.OnMovement += Movement;
        _cam= Camera.main;
        
    }


    public void Movement(Vector2 dir)
    {
        if (dir == Vector2.zero)
        {
            return;
        }

        Vector3 vec = new Vector3(0, 0, 0);
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
        transform.position += vec * 5 * Time.deltaTime;
    }
    
    
}
