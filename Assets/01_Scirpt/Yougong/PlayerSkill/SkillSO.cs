using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "SO/Skill/Base")]
public class SkillSO : ScriptableObject
{
    //public TextMeshPro _dmgSkin;
    [Header("Camera")] [SerializeField] protected float _shake = 6f;
    [SerializeField] protected float _time = 0.02f;
    [SerializeField] protected float _powerTime = 0.02f;
    
    [Header("Anime Speed")]
    [SerializeField] private float _animSpeed = 1f;
    
    [Header("Stat")] 
    [SerializeField] protected float _skillDamage;

    [SerializeField] protected float _criticalPercentage;
    [SerializeField] protected float _criticalDamage;

    [Header("IsNuckBack")] 
    [SerializeField] private bool _isNuckbackAble =true;

    [SerializeField] private Vector3 _localNuckBackVector = new Vector3(-1,0,0);
    [SerializeField] private float _NuckbackSpeed = 4f;
    
    protected CharacterInfo _info;
    protected ObjectStatSO WeaponStatSo;
    [Header("Info")] 
    [SerializeField] public FSMState State = FSMState.Attack;
    [SerializeField] public AnimationClip Clip = null;

    protected bool _isRunning = false;
    
    public virtual void Init(CharacterInfo info, ObjectStatSO weapon, ColliderCast cols)
    {
        
        _info = info;
        WeaponStatSo = weapon;
        
        cols.CastAct += SKillInvoke;
        cols.OnAnimEvnt += SkillEvent;
        cols.OnAnimEnd += SkillEnd;
        _info.AnimCon.Animator.speed = _animSpeed;

        if (Clip != null)
        {
            info.AnimCon.ChangeAnimationClip(State, Clip);
        }

        if ((info.FSM.CurrentState._myState != State || Clip != null) &&
            _info.FSM.CurrentState._myState != FSMState.NuckDown)
        {
            info.FSM.ChangeState(State);
            
        }

        _isRunning = false;
//        Debug.Log("스테이트 변경");

    }
    
    
    /// <summary>
    /// 치명타 계산 base
    /// </summary>
    /// <returns></returns>
    protected virtual bool CritReturn()
    {
        try
        {
            return Random.Range(0f, 100f) < _info.Stat.Crit + WeaponStatSo.Crit + _criticalPercentage ? true : false;
        }
        catch
        {

            Debug.LogWarning(_info);
            Debug.LogWarning(WeaponStatSo);
            Debug.LogWarning(_info.Stat);
            return true;
        }
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
        float x = CritReturn() == true
            ? ((_info.Stat.CritAmp + WeaponStatSo.CritAmp + _criticalDamage) * 0.01f) *
              ((_info.Stat.ATK + WeaponStatSo.ATK) * _skillDamage) + ((_info.Stat.ATK + WeaponStatSo.ATK) * _skillDamage)
            : (_info.Stat.ATK + WeaponStatSo.ATK) * _skillDamage;
        
        return x;
    }

    public virtual void SkillUpdate()
    {
        if (_info != null && _info.FSM.CurrentState._myState == FSMState.NuckDown)
            _isRunning = true;


    }

    public virtual void SkillEvent()
    {
        
    }

    public virtual void SkillEnd()
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
            if (_pl.gameObject.tag != "Player")
            { 
                CameraManager.Instance.Shakeing(_shake, _time);
                CameraManager.Instance.ScaleBind(_powerTime);
            }

            float value = DamageReturn();
            _pl.GetDamage(value);
            Debug.Log($"{_pl} : {value} damage");
        }
        
        if (_pl != null && _isNuckbackAble && _pl.IsNuckBackAble)
        {
            // 넉백
            _pl.StartCoroutine(NuckBack(_pl));
        }
    }

    protected virtual IEnumerator NuckBack(CharacterInfo _pl)
    {
        yield return null;
        
        if (_pl != null  && _pl.IsNuckBackAble ==false)
        {
            Vector3 dir = (_pl.transform.position - _info.transform.position).normalized;
            
            
            
            _pl.transform.localPosition += _localNuckBackVector * _NuckbackSpeed * Time.deltaTime;

            _pl.StartCoroutine(NuckBack(_pl));
        }


    }
    
    
    
}
