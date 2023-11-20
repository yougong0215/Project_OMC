using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponInString
{
    public Dictionary<PlayerWeaponSO.WEAPON_TYPE, string> _weaponName = new();
}

public class InventoriManager : MonoBehaviour
{
    [Header("CurrentWeapon")]
    public PlayerWeaponSO _shortWeapon = null;
    public PlayerWeaponSO _middleWeapon = null;
    public PlayerWeaponSO _bigWeapon = null;

    [Header("View Weapon")]
    public PlayerWeaponSO _viewWeapon = null;
    
    [Header("Weapons")]
    public List<PlayerWeaponSO> _weapons = new();

    private Dictionary<string, PlayerWeaponSO> _so = new();

    [Header("UI")] public Canvas _canvas;
    
    
    private void Awake()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            _so.Add(_weapons[i].ToString(), _weapons[i]);
        }
    }

    public void Open()
    {
        
    }

    public void SaveWeapon()
    {
        WeaponInString _cls = new();
        _cls._weaponName.Add(PlayerWeaponSO.WEAPON_TYPE.Short, _shortWeapon != null ? _shortWeapon.ToString() : "BaseShort");
        _cls._weaponName.Add(PlayerWeaponSO.WEAPON_TYPE.Middle, _middleWeapon != null ? _middleWeapon.ToString() : "BaseMiddle");
        _cls._weaponName.Add(PlayerWeaponSO.WEAPON_TYPE.Big, _bigWeapon != null ? _bigWeapon.ToString() : "BaseBig");
        string jsonData = JsonUtility.ToJson(_cls);
        string path = Path.Combine(Application.dataPath, "playerWeapon.json");
        File.WriteAllText(path, jsonData);
        
    }

    public void LoadWeapon()
    {
        string path = Path.Combine(Application.dataPath, "playerWeapon.json");
        string jsonData = File.ReadAllText(path);
        WeaponInString _cls = JsonUtility.FromJson<WeaponInString>(jsonData);
        _so.TryGetValue(_cls._weaponName[PlayerWeaponSO.WEAPON_TYPE.Short].ToString(), out _shortWeapon);
        _so.TryGetValue(_cls._weaponName[PlayerWeaponSO.WEAPON_TYPE.Middle].ToString(), out _middleWeapon);
        _so.TryGetValue(_cls._weaponName[PlayerWeaponSO.WEAPON_TYPE.Big].ToString(), out _bigWeapon);

    }
    
}
