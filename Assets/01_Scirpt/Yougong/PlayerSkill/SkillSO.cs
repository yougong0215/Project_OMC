using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Base")]
public class SkillSO : ScriptableObject
{
    public TextMeshPro _dmgSkin;
    private CharacterInfo _info;
    
    private ObjectStat _weaponStat;
    public FSMState State = FSMState.Attack;
    public AnimationClip Clip = null;
    
    public void Init(CharacterInfo info, ObjectStat weapon, ColliderCast cols)
    {
        _info = info;
        _weaponStat = weapon;
        cols.CastAct += SKillInvoke;
        
        if (Clip != null)
        {
            info.AnimCon.ChangeAnimationClip(State, Clip);
        }
        info.FSM.ChangeState(State);
//        Debug.Log("스테이트 변경");
        
    }
    
    
    /// <summary>
    /// 치명타 계산 base
    /// </summary>
    /// <returns></returns>
    protected virtual bool CritReturn()
    {
        return Random.Range(0f, 100f) < _info.Stat.Crit + _weaponStat.Crit ? true : false;
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
        return CritReturn() == true ? (_info.Stat.CritAmp + _weaponStat.CritAmp) * (_info.Stat.ATK + _weaponStat.ATK) 
            : (_info.Stat.ATK + _weaponStat.ATK);
    }

    /// <summary>
    /// cols의 게임오브잭트  접근 피격시 이벤트 발동
    /// if (cols.TryGetComponent(out CharacterInfo _pl))
    ///{
    ///    _pl.GetDamage(DamageReturn());
    ///}
    /// </summary>
    /// <param name="cols"></param>t
    public virtual void SKillInvoke(Collider cols)
    {
        Debug.Log("Invoke Active");
        if (cols.name != "Player")
        {
            TextMeshPro tmp = Instantiate(_dmgSkin) as TextMeshPro;
            tmp.transform.position = cols.transform.position;
            tmp.text = $"{Random.Range(1000, 10000000)}";
            tmp.transform.position += new Vector3(Random.Range(-0.2f, 0.2f),Random.Range(-0.2f, 0.2f),Random.Range(-0.2f, 0.2f));

        }
        
        if (cols.TryGetComponent(out CharacterInfo _pl))
        {
            _pl.GetDamage(DamageReturn());
        }
    }
    
    
    
}
