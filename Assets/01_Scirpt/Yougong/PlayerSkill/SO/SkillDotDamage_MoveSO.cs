using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Player/DotDmg")]
public class SkillDotDamage_MoveSO : SkillForwardMoveSO
{
    
        [Header("주기")]
        public float _time = 1f;
        [Header("반복")]
        public int _turm = 5;
        [Header("데미지 비율")]
        public float _dmgAmp = 0.1f;
    
    UnityEngine.Coroutine co = null;
    
    public override void SKillInvoke(Collider cols, bool Damaged =true)
    {

        Debug.Log("Invoke Active");
        
        if (cols.TryGetComponent(out CharacterInfo _pl) && Damaged)
        {
            
            if (_pl.gameObject.tag != "Player")
            { 
                CameraManager.Instance.Shakeing(_shake, _time);
                CameraManager.Instance.ScaleBind(_powerTime);
            }
            _pl.GetDamage(DamageReturn());
            DotDma(_pl,_time,_turm,_dmgAmp);
        }
    }

    void DotDma(CharacterInfo _pl, float time, int turn, float Damage)
    {
        if (_pl == null)
            return;

        if (co != null)
            co = null;
        co = _pl.StartCoroutine(DotDamage(_pl,time,turn-1,Damage));
    }

    protected virtual IEnumerator DotDamage(CharacterInfo _pl, float time, int turn, float Damage)
    {
        _pl.GetDamage(Damage);
        yield return new WaitForSeconds(time);
        if (turn > 0)
        {
            if (_pl.Stat.HP > 0)
            {
                
                DotDma(_pl,time,turn,Damage);
            }
        }
    }
}
