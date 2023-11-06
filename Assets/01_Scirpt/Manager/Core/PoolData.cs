using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PoolData")]
public class PoolData : ScriptableObject
{
    public List<PoolAble> prefabs = new();
}
