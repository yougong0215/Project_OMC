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


   [SerializeField] private PlayerCanvasM _canvas;

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
            GetDamage(0, true);
        }

        if(_canvas._hpBackBar.fillAmount > 0)
            _canvas._hpBackBar.fillAmount -= Time.deltaTime;
        else
        {
            _canvas._hpBackBar.fillAmount = 0;
        }
            
    }

    public override void GetDamage(float _damage, bool _nuckBack = false)
    {
        if (IsParring)
        {
            // Block 택스트 띄우기
            _isDamaged = true;
            return;
        }

        
        
        if(_nuckBack && _isDamaged==false)
        {
            if (FSMState.NuckDown != FSM.CurrentState._myState)
            {
                            
                if (HitDis != null)
                {
                    Debug.Log("hit");
                    HitDis.StartHiting();
                }
                FSM.ChangeState(FSMState.NuckDown);   
            }


        }
        //Debug.Log("불려오면안됨");
        
        Stat.HP -= (int)_damage;
        if (_co == null)
        {
            _co = StartCoroutine(Damaged());
            
        }

        _canvas._hpBackBar.fillAmount = _canvas._hpBar.fillAmount;
        _canvas._hpBar.fillAmount = Mathf.Lerp(0, 1, Stat.HP / statSo.HP);
    }
}
