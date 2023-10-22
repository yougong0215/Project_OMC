using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Base")]
public abstract class SkillSO : ScriptableObject
{
    private CharacterInfo _info;
    
    public void Init(CharacterInfo info, ColliderCast cols)
    {
        _info = info;
        cols.CastAct += SKillInvoke;
    }
    
    
    /// <summary>
    /// 치명타 계산 base
    /// </summary>
    /// <returns></returns>
    protected virtual bool CritReturn()
    {
        return Random.Range(0f, 100f) < _info.Stat.Crit ? true : false;
    }
    
    /// <summary>
    /// 데미지의 계산식 쓰기
    /// 없다면 본레 데미지 반환
    ///  return CritReturn() == true ? _playerCritAmp * _playerATK   : _playerATK;
    /// 원문
    /// </summary>
    /// <returns></returns>
    public virtual float DamageReturn()
    {
        return CritReturn() == true ? _info.Stat.CritAmp *_info.Stat.ATK  : _info.Stat.ATK ;
    }

    /// <summary>
    /// cols의 게임오브잭트  접근 피격시 이벤트 발동
    /// </summary>
    /// <param name="cols"></param>
    public virtual void SKillInvoke(Collider cols)
    {
        
    }
    
    
    
}
