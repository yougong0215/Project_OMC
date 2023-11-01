using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSO : MonoBehaviour
{
    [Header("좌클릭")]
    public ColliderCast L_Click;

    [Header("우클릭")]
    public ColliderCast R_Click;
    
    [Header("Q 스킬")]
    public ColliderCast Q_Skill;

    [Header("E 스킬")]
    public ColliderCast E_Skill;

    [Header("R 스킬")]
    public ColliderCast R_Skill;

    [SerializeField] public ObjectStat Stat = new ObjectStat();
}
