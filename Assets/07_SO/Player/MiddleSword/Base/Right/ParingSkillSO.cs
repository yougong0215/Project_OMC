using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Player/Parring")]
public class ParingSkillSO : SkillSO
{
    [Header("Parring")]
    [SerializeField] private float _parringTime;
    private PlayerInfo i;
    public override void SkillUpdate()
    {
        //base.SkillUpdate();
    }

    public override void SkillEvent()
    {
        if (_info.TryGetComponent<PlayerInfo>(out i))
        {
            i.ParringStart(_parringTime);
        }
        //base.SkillEvent();
    }

    public override void SKillInvoke(Collider cols, bool Damaged = true)
    {
        
        //base.SKillInvoke(cols, Damaged);
    }
}

