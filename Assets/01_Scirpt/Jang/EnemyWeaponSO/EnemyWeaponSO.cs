using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/Enemy")]
public class EnemyWeaponSO : WeaponSO
{
    [Header("위에는 Stat만 빼고 무시하기")]
    [Header("일반공격1")]
    public ColliderCast Normal_Attack_1;

    [Header("일반공격2")]
    public ColliderCast Normal_Attack_2;

    [Header("일반공격3")]
    public ColliderCast Normal_Attack_3;

    [Header("강공")]
    public ColliderCast Power_Attack;

    [Header("속공")]
    public ColliderCast Speed_Attack;

    [Header("발사체")]
    public ColliderCast Throw_Attack;
}
