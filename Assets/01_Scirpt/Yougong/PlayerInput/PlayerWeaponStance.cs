using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerWeaponStance : MonoBehaviour
{
    [Header("Default IdleAnim")] public AnimationClip _clip;
    protected PlayerInfo _player;

    private PlayerInput _input;
    [Header("WeaponList")]

    public List<PlayerWeaponSO> weaponList;
    
    public PlayerWeaponSO _currentWeapon;
    
    public PlayerSkillListSO _CurrentSkill;
    private int nowNum = 0;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _player = GetComponent<PlayerInfo>();

        if (_currentWeapon == null)
        {
            ChangeStance(weaponList[0]);
        }
        else
        {
            ChangeStance(_currentWeapon);
        }

        _input.TabBtn += () => ChangeStance(weaponList[(++nowNum)%weaponList.Count]);
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
        if (_so == null)
        {
            
            return;
        }
        
        Debug.Log($"{_so.ToString()}쿨타임 : {_so._currentCooltime}");
        
        
        

        // 스킬이 같으면서 사용중이면 콤보 연계
        if (_so == _CurrentSkill && _so.IsRunning)
        {
            Debug.Log(1);
            if( _so.NoneCombo == false)
            {
                _so.ComboSet();
            }
            else
            {
                Debug.Log("SKILLSYSTEM : 그냥 안됨 ㅋ");
            }
            return;
        }
        
        // 다를시 콤보 끊기
        if (_CurrentSkill != _so)
        {
            if(_CurrentSkill != null)
                _CurrentSkill.NoneCombo = true;
        }

        // 현제 실행중인 스킬이 있으면 안됨
        if (_CurrentSkill != null && _CurrentSkill.IsRunning)
        {
            Debug.Log(2);
            if(_CurrentSkill)
            
            return;
        }

        // 쿨타임 돌면 됨
        if (_so.IsCanPlay())
        {
            
            Debug.Log(3);
            return;
        }



            
        _CurrentSkill = _so;

        
        
        Debug.Log("Suceess");
        if ((int)_player.FSM.CurrentState._myState < 12)
        {
            StartCoroutine(_so.SkillAct(this,_player, _currentWeapon, transform));
            //StartCoroutine(_so.R_Click.UpdateLayer());
        }
    }

    public void ChangeStance(PlayerWeaponSO _so)
    {
        if (_so == null)
            return;
        
        if (_so._idleCilp != null)
        {
            _player.AnimCon.ChangeAnimationClip(FSMState.Idle, _so._idleCilp);
        }
        else
        {
            _player.AnimCon.ChangeAnimationClip(FSMState.Idle, _clip);
        }
       
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
