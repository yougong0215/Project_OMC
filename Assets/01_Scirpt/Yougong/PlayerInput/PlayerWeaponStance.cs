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
    [Header("Cavans")] [SerializeField]private PlayerCanvasM _canvas;
    public bool _isOpen = false;
    [Header("Hands")]
    [SerializeField] private Transform HandPos = null;

    private GameObject _currentWeaponModel = null;

    public bool _superArrmor = false;
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

        _input.TabBtn += TabBtn;
        _input.ESCBtn += ()=>_canvas.Close(true);

        //_input.TabBtn += () => ChangeStance(weaponList[(++nowNum)%weaponList.Count]);
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
                if (_currentWeapon.R_Click == weaponList[i]._skills[j])
                {
                    _canvas.SkillCooldown(SkillBtn.Left, _currentWeapon.R_Click.MaxCool(),_currentWeapon.R_Click._currentCooltime);
                }
                else if (_currentWeapon.Q_Skill == weaponList[i]._skills[j])
                {
                    _canvas.SkillCooldown(SkillBtn.Q, _currentWeapon.Q_Skill.MaxCool(),_currentWeapon.Q_Skill._currentCooltime);
                }
                else if (_currentWeapon.E_Skill == weaponList[i]._skills[j])
                {
                    _canvas.SkillCooldown(SkillBtn.E, _currentWeapon.E_Skill.MaxCool(),_currentWeapon.E_Skill._currentCooltime);
                }
                else if (_currentWeapon.R_Skill == weaponList[i]._skills[j])
                {
                    _canvas.SkillCooldown(SkillBtn.R, _currentWeapon.R_Skill.MaxCool(),_currentWeapon.R_Skill._currentCooltime);
                }
            }
        }

        if (_player.FSM.CurrentState._myState == FSMState.NuckDown)
        {
            if (_CurrentSkill != null)
            {
                _CurrentSkill.SetOffRunning();
                _CurrentSkill = null;
            }
        }
    }

    public void TabBtn()
    {
        _canvas.Open();
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
            if ((int)_player.FSM.CurrentState._myState < 11)
            {
                _CurrentSkill.SetOffRunning();
            }
            else
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

    public void ChangeWeaponUI(int value)
    {
        _canvas.Close();
        if(value != 3)
        ChangeStance(weaponList[value]);
    }

    public void ChangeStance(PlayerWeaponSO _so)
    {
        if (_so == null)
            return;
        if (_currentWeaponModel != null)
        {
            Destroy(_currentWeaponModel);
        }

        _currentWeaponModel = Instantiate(_so._weaponModel, HandPos);
        
        
        Debug.LogWarning(_so.R_Click._icon.name);
        _canvas.SetSkillIcon(SkillBtn.Left, _so.R_Click != null ? _so.R_Click._icon : null);
        _canvas.SetSkillIcon(SkillBtn.Q, _so.Q_Skill != null ? _so.Q_Skill._icon : null);
        _canvas.SetSkillIcon(SkillBtn.E, _so.E_Skill != null ? _so.E_Skill._icon : null);
        _canvas.SetSkillIcon(SkillBtn.R, _so.R_Skill != null ? _so.R_Skill._icon : null);
        
        
        Debug.Log(_player.AnimCon);
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
