using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInfo : CharacterInfo
{
    private PlayerInput _input;
    public PlayerInput Input => _input;

    private PlayerMovement _move;
    public PlayerMovement Move => _move;

    bool IsParring = false;
    protected override void AwakeInvoke()
    {
        _input = GetComponent<PlayerInput>();
        _move = GetComponent<PlayerMovement>();
    }

    public void ParringStart(float time)
    {
        StartCoroutine(ParringCo(time));
    }

    IEnumerator ParringCo(float times)
    {
        if(IsDamage==false)
        IsParring = true;
        yield return new WaitForSeconds(times);
        IsParring = false;
    }

    public bool CanParring()
    {
        if (IsParring == true && IsDamage == true)
            return true;
        return false;   
    }

    private void Update()
    {
        // Debug.Log(IsDamage);
        if (UnityEngine.Input.GetKeyDown(KeyCode.X))
        {
            GetDamage(0);
        }
    }

    public override void GetDamage(float _damage)
    {
        if (IsParring)
        {
            // Block 택스트 띄우기
            _isDamaged = true;
            return;
        }
        //Debug.Log("불려오면안됨");
        
        statSo.HP -= (int)_damage;
        if (_co == null)
        {
            _co = StartCoroutine(Damaged());
            
        }
    }
}
