using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/SkillList/Parrying")]
public class ParryingSkillListSO : PlayerSkillListSO
{
public override IEnumerator SkillAct(PlayerWeaponStance weapons,CharacterInfo _char, WeaponSO _currentWeapon, Transform tls)
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

        ColliderCast A = Instantiate(Attacks[0].cols, obj.transform);  
        CurrentObject = A;
        A.Init(_char, _currentWeapon.statSo);
        PlayerInfo i;
        if ( A._player.TryGetComponent<PlayerInfo>(out i))
        {
            
        }
        yield return new WaitUntil(() => i.CanParring() || A.ReturnColliderEnd() == true); // 조건 바꾸기

        if (i.CanParring() == true)
        {
            Debug.Log("패링성공");
            for (currnetNum = 1; currnetNum < Attacks.Count; currnetNum++)
            {
                if (Attacks[currnetNum].comboLive==false || (ComboInterective && Attacks[currnetNum].comboLive))
                {
                    ComboInterective = false;
                
                    ColliderCast cols = Instantiate(Attacks[currnetNum].cols, obj.transform);    
                    CurrentObject = cols;
                    cols.Init(_char, _currentWeapon.statSo);
                
                    yield return new WaitUntil(() => cols.ReturnColliderEnd() == true || Attacks[currnetNum].isNotWaiting == true);
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
}
