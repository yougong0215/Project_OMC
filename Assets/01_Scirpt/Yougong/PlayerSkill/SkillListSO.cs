using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillListSO : ScriptableObject,ISerializationCallbackReceiver
{
    [Header("SkillSO")]
    
    protected bool _isRunning = false;
    public bool IsRunning => _isRunning;
    public List<ColliderCast> Attacks = new();
    
    
    public virtual IEnumerator SkillAct(GameObject _me, CharacterInfo _char,WeaponSO _currentWeapon, Transform tls)
    {
        _isRunning = true;
        for (int i = 0; i < Attacks.Count; i++)
        {
            ColliderCast obj = Instantiate(Attacks[i], tls);
            obj.Init(_char, _currentWeapon.statSo);
            yield return new WaitUntil(() => obj.ReturnColliderEnd());
        }

        _isRunning = false;
        yield return new WaitForSeconds(1f);
        Destroy(_me);
    }
    public void OnBeforeSerialize()
    {
        _isRunning = false;
    }

    public void OnAfterDeserialize()
    {
        
    }
    
}
