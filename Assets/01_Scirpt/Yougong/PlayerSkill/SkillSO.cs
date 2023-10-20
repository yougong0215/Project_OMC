using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Base")]
public abstract class SkillSO : ScriptableObject
{
    private float _playerATK;
    private float _playerCrit;
    private float _playerCritAmp;
    


    public void Init(float playerATK, float playerCrit, float playerCritAmp, ColliderCast cols)
    {
        _playerATK = playerATK;
        _playerCrit = playerCrit;
        _playerCritAmp = playerCritAmp;

        cols.CastAct += SKillInvoke;
    }
    

    protected virtual bool CritReturn()
    {
        return Random.Range(0f, 100f) < _playerCrit ? true : false;
    }
    
    /// <summary>
    /// 데미지의 계산식 쓰기
    /// 없다면 본레 데미지 반환
    /// </summary>
    /// <returns></returns>
    public virtual float DamageReturn()
    {
        return CritReturn() == true ? _playerCritAmp * _playerATK   : _playerATK ;
    }

    /// <summary>
    /// cols의 게임오브잭트 접근
    /// </summary>
    /// <param name="cols"></param>
    public virtual void SKillInvoke(Collider cols)
    {
        
    }
    
    
    
}
