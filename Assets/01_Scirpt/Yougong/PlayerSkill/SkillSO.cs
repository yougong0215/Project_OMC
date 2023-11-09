using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Base")]
public class SkillSO : ScriptableObject
{
    //public TextMeshPro _dmgSkin;
    [Header("Anime Speed")]
    [SerializeField] private float _animSpeed = 1f;
    
    [Header("Stat")] 
    [SerializeField] protected float _skillDamage;

    [SerializeField] protected float _criticalPercentage;
    [SerializeField] protected float _criticalDamage;
    
    protected CharacterInfo _info;
    
    protected ObjectStatSO WeaponStatSo;
    public FSMState State = FSMState.Attack;
    public AnimationClip Clip = null;
    
    public virtual void Init(CharacterInfo info, ObjectStatSO weapon, ColliderCast cols)
    {
        _info = info;
        WeaponStatSo = weapon;
        cols.CastAct += SKillInvoke;
        cols.OnAnimEvnt += SkillEvent;
        _info.AnimCon.Animator.speed = _animSpeed;

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
        return Random.Range(0f, 100f) < _info.StatSo.Crit + WeaponStatSo.Crit + _criticalPercentage ? true : false;
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
        return CritReturn() == true ? ((_info.StatSo.CritAmp + WeaponStatSo.CritAmp + _criticalDamage)*0.01f) * ((_info.StatSo.ATK + WeaponStatSo.ATK) * _skillDamage)
            : (_info.StatSo.ATK + WeaponStatSo.ATK) * _skillDamage;
    }

    public virtual void SkillUpdate()
    {
        
    }

    public virtual void SkillEvent()
    {
        
    }
    /// <summary>
    /// cols의 게임오브잭트  접근 피격시 이벤트 발동
    /// if (cols.TryGetComponent(out CharacterInfo _pl))
    ///{
    ///    _pl.GetDamage(DamageReturn());
    ///}
    /// </summary>
    /// <param name="cols"></param>t
    public virtual void SKillInvoke(Collider cols, bool Damaged =true)
    {
        Debug.Log("Invoke Active");
        //if (cols.name != "Player")
        //{
        //    if(_dmgSkin == null)
        //    return;
        //    TextMeshPro tmp = Instantiate(_dmgSkin) as TextMeshPro;
        //    tmp.transform.position = cols.transform.position;
        //    tmp.text = $"{Random.Range(1000, 10000000)}";
        //    tmp.transform.position += new Vector3(Random.Range(-0.2f, 0.2f),Random.Range(-0.2f, 0.2f),Random.Range(-0.2f, 0.2f));
        //
        //}
        
        if (cols.TryGetComponent(out CharacterInfo _pl) && Damaged)
        {
            _pl.GetDamage(DamageReturn());
        }
    }
    
    
    
    
    
}
