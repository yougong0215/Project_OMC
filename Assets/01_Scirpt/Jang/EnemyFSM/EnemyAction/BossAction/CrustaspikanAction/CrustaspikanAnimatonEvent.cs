using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanAnimatonEvent : MonoBehaviour
{
    [SerializeField] private EnemyWeaponStance[] weaponStances;
    private CrustaspikanInfo info;
    private FSM fsm;

    private void Awake()
    {
        info = transform.parent.GetComponent<CrustaspikanInfo>();
        fsm = info.GetComponentInChildren<FSM>();
    }

    public void OnPanntenAnimationChange()
    {
        info.RandomPatten();

        if (fsm.NowState() == FSMState.Attack)
        {
            foreach (EnemyWeaponStance weaponStance in weaponStances)
                weaponStance.ChangeColliderCase(info.NowAttackEnum());
        }
    }

    public void OnDashAnimation()
    {
        info.DashInit();
    }
}
