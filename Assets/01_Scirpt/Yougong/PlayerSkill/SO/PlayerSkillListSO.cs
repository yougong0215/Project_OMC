using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[System.Serializable]
public class SkillCollider
{
    public ColliderCast cols;
    public bool comboLive = false;
    public bool isNotWaiting = false;
    public bool isPosition = false;
    public bool isNextSkip = false;
    public float delayTime = .05f;
}

    [CreateAssetMenu(menuName = "SO/Player/SkillList/Base")]
public class PlayerSkillListSO : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Info")] [SerializeField] protected float CoolTime = 8f;
    [SerializeField] public float _currentCooltime = 0;
    [SerializeField] public float _dampingCooltime =2f;
    protected int currnetNum = 0;
    protected bool ComboInterective = false;
    [NonSerialized] public bool NoneCombo = false;
    
    protected bool _isRunning = false;
    public bool IsRunning => _isRunning;

    public ColliderCast CurrentObject;



    public void SetOffRunning()
    {
        _isRunning = false;
    }
    
    public List<SkillCollider> Attacks = new();

    public bool IsCanPlay()
    {
        if (_currentCooltime > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        //return _currentCooltime <= 0;
    }

    /// <summary>
    /// 공격 판정이 들어갈때부터 콤보 잇기 가능
    /// </summary>
    public void ComboSet()
    {
        if (CurrentObject == null)
            return;
        
        if (CurrentObject.IsAttack == true)
        {
            ComboInterective = true;
            Debug.Log("SKILLSYSTEM : 성공!");
        }
        else
        {
            if (Attacks.Count > currnetNum)
            {
                
            Debug.Log($"SKILLSYSTEM : 실패! {Attacks[currnetNum].cols.IsAttack}");
            }
        }
    }

    public IEnumerator StopFinding(ColliderCast col)
    {
        col.Attack(true);
        Debug.Log("삭제 시퀀스");
        yield return new WaitForSeconds(0.2f);
        
        col.Attack(false);
        yield return new WaitForSeconds(1f);
        Destroy(col.gameObject);
    }
    
    public virtual IEnumerator SkillAct(PlayerWeaponStance weapons,CharacterInfo _char, WeaponSO _currentWeapon, Transform tls)
    {
        NoneCombo = false;
        _currentCooltime = CoolTime + _dampingCooltime;
        Vector3 vec = tls.position;
        Quaternion rot = tls.rotation;
        GameObject obj = new GameObject();
        obj.transform.position = tls.position;
        obj.transform.rotation = tls.rotation;
        //obj.transform.parent = null;
        
        _isRunning = true;

        for (currnetNum = 0; currnetNum < Attacks.Count; currnetNum++)
        {
            if (Attacks[currnetNum].comboLive==false || (ComboInterective && Attacks[currnetNum].comboLive))
            {
                ComboInterective = false;
                ColliderCast cols;
                if (Attacks[currnetNum].comboLive == true || Attacks[currnetNum].isPosition)
                { 
                    cols = Instantiate(Attacks[currnetNum].cols, _char.transform);
                }
                else
                {
                    cols = Instantiate(Attacks[currnetNum].cols, obj.transform);
                }
                
                Debug.LogWarning(Attacks[currnetNum]);
                //cols.transform.position = vec;
                //cols.transform.rotation = rot;
                
                CurrentObject = cols;
                cols.Init(_char, _currentWeapon.statSo);
                
                yield return new WaitUntil(() => cols.ReturnColliderEnd() == true || Attacks[currnetNum].isNotWaiting == true
                    || Attacks[currnetNum].isNextSkip == true);
                if (Attacks[currnetNum].isNotWaiting == false)
                {
                    Destroy(cols.gameObject, 2f);
                }
                else
                {
                    MonoBehaviour mono = _char.GetComponent<MonoBehaviour>();
                    mono.StartCoroutine(StopFinding(CurrentObject));
                    yield return new WaitForSeconds(Attacks[currnetNum].delayTime);
                }
                
            }
            else
            {
                break;
            }
        }
        Debug.Log("빠져나옴");
        Destroy(obj);
        _isRunning = false;

        yield return new WaitUntil(() => _char.AnimCon.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        if (_char.FSM.CurrentState._myState != FSMState.Run &&
            _char.FSM.CurrentState._myState != FSMState.Idle &&
            _char.FSM.CurrentState._myState <= _char.FSM.CurrentState._myState && 
            weapons._CurrentSkill == this) 
            _char.FSM.ChangeState(FSMState.Idle);
    }

    public void OnBeforeSerialize()
    {
        _currentCooltime = 0;
        currnetNum = 0;
        _isRunning = false;
        CurrentObject = null;
        NoneCombo = false;
    }

    public void OnAfterDeserialize()
    {
        _currentCooltime = 0;
        currnetNum = 0;
        _isRunning = false;
        CurrentObject = null;
        NoneCombo = false;
        //throw new System.NotImplementedException();
    }
}
