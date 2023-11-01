using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerInfo _info;
    
    private Camera _cam;
    private Vector3 vec;
    private float moveUpTime = 0.0f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _gravityScale = 1;
    

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _info = GetComponent<PlayerInfo>();
        _input.OnMovement += Movement;
        _cam= Camera.main;
        
    }


    public void Movement(Vector2 dir)
    {
//        Debug.LogWarning("여서 FSM Move 변경");


        if (!Physics.Raycast(transform.position, Vector3.down, 1.7f, _ground))
        {
            vec.y = _gravity / 5 * _gravityScale;
        }
        else
        {
            vec.y = 0;
        }
        transform.position += vec * _info.Stat.SPEED * Time.deltaTime;
        
        

        if (moveUpTime < 0f)
        {
            moveUpTime = 0;
        }
        
        if (dir == Vector2.zero ||  (int)_input._fsm.CurrentState._myState > 10)
        {
            moveUpTime -= Time.deltaTime;
            
            if(Mathf.Abs(vec.x) > 0.1f)
                vec.x = Mathf.Abs(vec.x) - (_info.Stat.SPEED*Time.deltaTime);
            else
                vec.x = 0;
            
            if(Mathf.Abs(vec.y) > -_gravity)
                vec.y = Mathf.Abs(vec.y) - (_info.Stat.SPEED*Time.deltaTime);
            else
                vec.y = -9.8f;
            
            if(Mathf.Abs(vec.z) > 0.1f)
                vec.z = Mathf.Abs(vec.z) - (_info.Stat.SPEED*Time.deltaTime);
            else
                vec.z = 0;

            if (vec.x == 0 && vec.z == 0 && (int)_input._fsm.CurrentState._myState < 10)
            {
                _input._fsm.ChangeState(FSMState.Idle);
            }
            
            return;
        }

        if ((int)_input._fsm.CurrentState._myState < 10)
        {
            _input._fsm.ChangeState(FSMState.Run);
        }

        moveUpTime += Time.deltaTime * 4;
        if (moveUpTime > 1f)
        {
            moveUpTime = 1;
        }


        vec = Vector3.zero;
        if (dir.y >= 0.7)
            vec += _cam.transform.forward * moveUpTime;
        else if (dir.y <= -0.7)
            vec += -_cam.transform.forward * moveUpTime;

        if (dir.x >= 0.7)
            vec += _cam.transform.right * moveUpTime;
        else if (dir.x <= -0.7)
            vec += -_cam.transform.right * moveUpTime;
        
        Quaternion t  = Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, t, Time.deltaTime * _info.Stat.SPEED);

//        print(dir);
        
    }
    
    
}
