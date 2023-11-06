using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerWeaponStance : MonoBehaviour
{
    protected PlayerInfo _player;

    private PlayerInput _input;

    public List<PlayerWeaponSO> weaponList;
    
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

    private void Update()
    {
        ///최대 3x5 돌아감
        for (int i = 0; i < weaponList.Count; i++)
        {
            for (int j = 0; j < weaponList[i]._skills.Count; j++)
            {
//                Debug.Log(weaponList[i]._skills[j].name);
                weaponList[i]._skills[j]._currentCooltime -= Time.deltaTime;
            }
        }
    }

    public void SkillInvoke(PlayerSkillListSO _so)
    {
            
        if(_so != null && _CurrentSkill == _so && _input._fsm.CurrentState._myState == FSMState.Attack)
        {
            _so.ComboSet();
            return;
        }
            
        if ( _so == null || (_CurrentSkill != null && _CurrentSkill.IsCanPlay() == false))
            return;

        _CurrentSkill = _so;
            
        Debug.Log("좌클릭");
        //Debug.Log(s);
        if (_so.IsRunning == false || (int)_input._fsm.CurrentState._myState <= 10)
        {
            StartCoroutine(_so.SkillAct(this,_player, _currentWeapon, transform));
            //StartCoroutine(_so.R_Click.UpdateLayer());
        }
    }

    public void ChangeStance(PlayerWeaponSO _so)
    {
         _input.SkillInputReset();
        
        _currentWeapon = _so;
        
        
        _input.OnLeftClick += () =>
        {
            SkillInvoke(_so.L_Click);
        };
        
        _input.OnRightClick += () =>
        {
            SkillInvoke(_so.R_Click);

        };
        
        _input.Q_Btn += () =>
        { 
            SkillInvoke(_so.Q_Skill);

        };
        
        _input.E_Btn += () =>
        {
            SkillInvoke(_so.E_Skill);
        };
        
        _input.R_Btn += () =>
        {
            SkillInvoke(_so.R_Skill);
        };
    }
    
    
    
    
}
