using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//[CreateAssetMenu(menuName = "SO/Weapon")]
public abstract class WeaponSO : ScriptableObject
{
    [FormerlySerializedAs("Stat")] [SerializeField] public ObjectStatSO statSo;
}
