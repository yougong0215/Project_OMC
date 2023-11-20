using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/Enemy")]
public class EnemyWeaponSO : WeaponSO
{
    [Header("������ Stat�� ���� �����ϱ�")]
    [Header("�Ϲݰ���1")]
    public ColliderCast Normal_Attack_1;

    [Header("�Ϲݰ���2")]
    public ColliderCast Normal_Attack_2;

    [Header("�Ϲݰ���3")]
    public ColliderCast Normal_Attack_3;

    [Header("����")]
    public ColliderCast Power_Attack;

    [Header("�Ӱ�")]
    public ColliderCast Speed_Attack;

    [Header("�߻�ü")]
    public ColliderCast Throw_Attack;
}
