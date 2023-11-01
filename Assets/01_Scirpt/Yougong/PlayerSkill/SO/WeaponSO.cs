using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "SO/Weapon")]
public abstract class WeaponSO : ScriptableObject
{
    [SerializeField] public ObjectStat Stat = new ObjectStat();
}
