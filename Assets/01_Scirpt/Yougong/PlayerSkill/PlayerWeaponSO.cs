using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Weapon")]
public class PlayerWeaponSO : WeaponSO,ISerializationCallbackReceiver
{
    public enum WEAPON_TYPE
    {
        Short,
        Middle,
        Big
    }

    [Header("Item")] public GameObject _weaponModel;

    [Header("SOType")] public WEAPON_TYPE _type;
    
    
    [SerializeField] public List<PlayerSkillListSO> _skills = new();
    [Header("IdleClip")]
    [SerializeField] public AnimationClip _idleCilp;
    

    [Header("좌클릭")]
    public PlayerSkillListSO L_Click;

    [Header("우클릭")]
    public PlayerSkillListSO R_Click;
    
    [Header("Q 스킬")]
    public PlayerSkillListSO Q_Skill;

    [Header("E 스킬")]
    public PlayerSkillListSO E_Skill;

    [Header("R 스킬")]
    public PlayerSkillListSO R_Skill;
    
    
    

    public void OnBeforeSerialize()
    {
        _skills.Clear();
        if(L_Click != null)
            _skills.Add(L_Click);
        if(R_Click != null)
            _skills.Add(R_Click);
        if(Q_Skill != null)
            _skills.Add(Q_Skill);
        if(E_Skill != null)
            _skills.Add(E_Skill);
        if(R_Skill != null)
            _skills.Add(R_Skill);
    }

    public void OnAfterDeserialize()
    {
    }
}
