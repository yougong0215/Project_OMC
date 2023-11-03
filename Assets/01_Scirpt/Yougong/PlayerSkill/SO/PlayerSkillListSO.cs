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
    public float delayTime = .05f;
}

    [CreateAssetMenu(menuName = "SO/Player/SkillList")]
public class PlayerSkillListSO : ScriptableObject, ISerializationCallbackReceiver
{
    private int currnetNum = 0;
    bool ComboInterective = false;
    
    protected bool _isRunning = false;
    public bool IsRunning => _isRunning;

    public ColliderCast CurrentObject;
    
    
    
    public List<SkillCollider> Attacks = new();

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
//            Debug.Log("SKILLSYSTEM : 성공!");
        }
        else
        {
//            Debug.Log($"SKILLSYSTEM : 실패! {Attacks[currnetNum].cols.IsAttack}");
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
    
    public IEnumerator SkillAct(CharacterInfo _char, WeaponSO _currentWeapon, Transform tls)
    {
        
        _isRunning = true;

        for (currnetNum = 0; currnetNum < Attacks.Count; currnetNum++)
        {
            if (Attacks[currnetNum].comboLive==false || (ComboInterective && Attacks[currnetNum].comboLive))
            {
                ComboInterective = false;
                ColliderCast cols = Instantiate(Attacks[currnetNum].cols, tls);
                CurrentObject = cols;
                cols.Init(_char, _currentWeapon.Stat);
                
                yield return new WaitUntil(() => cols.ReturnEnd() == true || Attacks[currnetNum].isNotWaiting == true);
                if (Attacks[currnetNum].isNotWaiting == false)
                {
                    Destroy(cols.gameObject);
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
//        Debug.Log("빠져나옴");

        yield return new WaitUntil(() => _char.AnimCon.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        _isRunning = false;
        if (_char.FSM.CurrentState._myState != FSMState.Idle) 
        _char.FSM.ChangeState(FSMState.Idle);
    }

    public void OnBeforeSerialize()
    {
        currnetNum = 0;
        _isRunning = false;
        CurrentObject = null;
    }

    public void OnAfterDeserialize()
    {
        //throw new System.NotImplementedException();
    }
}
