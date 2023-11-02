using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerWeaponStance : MonoBehaviour
{
    protected PlayerInfo _player;

    private PlayerInput _input;
    
    public PlayerWeaponSO _currentWeapon;
    
    [NonSerialized] public PlayerSkillListSO _CurrentSkill;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _player = GetComponent<PlayerInfo>();

        if (_currentWeapon != null)
        {
            ChangeStance(_currentWeapon);
        }
    }

    public void ChangeStance(PlayerWeaponSO _so)
    {
         _input.SkillInputReset();
        
        _currentWeapon = _so;
        
        
        _input.OnLeftClick += () =>
        {
            PlayerSkillListSO s=  _so.L_Click;
                _CurrentSkill = s;
            if (s == null)
                return;
            
            Debug.Log("좌클릭");
            if (s.IsRunning == false && _input._fsm.CurrentState._myState != FSMState.Attack)
            {
                StartCoroutine(s.SkillAct(_player, _currentWeapon, transform));
                //StartCoroutine(_so.L_Click.UpdateLayer());
            }
            else if(_input._fsm.CurrentState._myState == FSMState.Attack)
            {
                
                s.ComboSet();
            }
            
        };
        
        _input.OnRightClick += () =>
        {
            Debug.Log("우클릭");
            PlayerSkillListSO s=  _so.R_Click;
            _CurrentSkill = s;
            if (s == null)
                return;
            if (s.IsRunning ==false&& _input._fsm.CurrentState._myState != FSMState.Attack)
            {
                StartCoroutine(s.SkillAct(_player, _currentWeapon, transform));
                //StartCoroutine(_so.L_Click.UpdateLayer());
            }
            else if(_input._fsm.CurrentState._myState == FSMState.Attack)
            {
                s.ComboSet();
            }
        };
        
        _input.Q_Btn += () =>
        {
            PlayerSkillListSO s=  _so.Q_Skill;
            _CurrentSkill = s;
            if (s == null)
                return;
            if (s.IsRunning ==false&& _input._fsm.CurrentState._myState != FSMState.Attack)
            {
                Debug.Log("Q클릭");
                StartCoroutine(s.SkillAct(_player, _currentWeapon, transform));
                //StartCoroutine(_so.L_Click.UpdateLayer());
            }
            else if(_input._fsm.CurrentState._myState == FSMState.Attack)
            {
                s.ComboSet();
            }
        };
        
        _input.E_Btn += () =>
        {
            PlayerSkillListSO s=  _so.E_Skill;
            if (s == null)
                return;
            
            Debug.Log("E클릭");
            _CurrentSkill = s;
            if (s.IsRunning ==false&& _input._fsm.CurrentState._myState != FSMState.Attack)
            {
                StartCoroutine(s.SkillAct(_player, _currentWeapon, transform));
                //StartCoroutine(_so.L_Click.UpdateLayer());
            }
            else if(_input._fsm.CurrentState._myState == FSMState.Attack)
            {
                s.ComboSet();
            }
        };
        
        _input.R_Btn += () =>
        {
            PlayerSkillListSO s=  _so.R_Skill;
            if (s == null)
                return;
            Debug.Log("R클릭");
            _CurrentSkill = s;
            if (s.IsRunning ==false&& _input._fsm.CurrentState._myState != FSMState.Attack)
            {
                StartCoroutine(s.SkillAct(_player, _currentWeapon, transform));
                //StartCoroutine(_so.L_Click.UpdateLayer());
            }
            else if(_input._fsm.CurrentState._myState == FSMState.Attack)
            {
                s.ComboSet();
            }
        };
    }
    
    
    
    
}
