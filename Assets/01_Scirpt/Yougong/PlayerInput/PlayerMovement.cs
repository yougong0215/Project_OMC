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
    private float moveUpTime = 0.0f;
    

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _input.OnMovement += Movement;
        _cam= Camera.main;
        
    }


    public void Movement(Vector2 dir)
    {
        Debug.LogWarning("여서 FSM Move 변경");
        
        transform.position += vec * Time.deltaTime;
        
        

        if (moveUpTime < 0f)
        {
            moveUpTime = 0;
        }
        
        if (dir == Vector2.zero ||  (int)_input._fsm.CurrentState._myState > 10)
        {
            moveUpTime -= Time.deltaTime;
            
            if(Mathf.Abs(vec.x) > 0.1f)
                vec.x = Mathf.Abs(vec.x) - (4*Time.deltaTime);
            else
                vec.x = 0;
            
            if(Mathf.Abs(vec.y) > 9.8f)
                vec.y = Mathf.Abs(vec.y) - (4*Time.deltaTime);
            else
                vec.y = -9.8f;
            
            if(Mathf.Abs(vec.z) > 0.1f)
                vec.z = Mathf.Abs(vec.z) - (4*Time.deltaTime);
            else
                vec.z = 0;
            
            if (vec == Vector3.zero)
            {
                _input._fsm.ChangeState(FSMState.Idle);
            }
            
            return;
        }

        if ((int)_input._fsm.CurrentState._myState <= 10)
        {
            _input._fsm.ChangeState(FSMState.Run);
        }

        moveUpTime += Time.deltaTime;
        if (moveUpTime > 1f)
        {
            moveUpTime = 1;
        }

        
        vec = new Vector3(0, 0, 0);
        if (dir.y >= 0.7)
            vec += _cam.transform.forward * moveUpTime;
        else if (dir.y <= -0.7)
            vec += -_cam.transform.forward * moveUpTime;

        if (dir.x >= 0.7)
            vec += _cam.transform.right * moveUpTime;
        else if (dir.x <= -0.7)
            vec += -_cam.transform.right * moveUpTime;
        
        Quaternion t  = Quaternion.LookRotation(vec);
        transform.rotation = Quaternion.Lerp(transform.rotation, t, Time.deltaTime * 7);
        vec.y = -9.8f;
        print(dir);
        
    }
    
    
}
