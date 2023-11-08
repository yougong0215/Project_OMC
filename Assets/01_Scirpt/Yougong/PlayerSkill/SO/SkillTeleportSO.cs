using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Skill/Teleport")]
public class SkillTeleportSO : SkillSO
{
    private float distance = 5;
    
    private Camera _cam;
    public Camera Cam
    {
        get
        {
            if (_cam == null)
            {
                _cam = Camera.main;
            }
            return _cam;
        }
    }
    
    public override void SkillEvent()
    {
        if (_info.TryGetComponent<PlayerInfo>(out PlayerInfo i))
        {
            Vector2 dir = i.Input.InputVector();
            Vector3 vec = Vector3.zero; // 마우스 방향
            
            if (dir.y >= 0.7)
                vec += Cam.transform.forward.normalized;
            else if (dir.y <= -0.7)
                vec += -Cam.transform.forward.normalized;

            if (dir.x >= 0.7)
                vec += Cam.transform.right.normalized;
            else if (dir.x <= -0.7)
                vec += -Cam.transform.right.normalized;


            vec.y = _info.transform.position.y + 1;
            
            if (!Physics.Raycast(_info.transform.position, vec, out RaycastHit ray, distance))
            {
                _info.transform.position = ray.point;
            }
            else
            {
                _info.transform.position += vec;
            }
            
        }
    }
    
    public override void SkillUpdate()
    {
        
    }
    
    public override void SKillInvoke(Collider cols, bool Damaged = true)
    {
        base.SKillInvoke(cols,false);
        // if (cols.TryGetComponent(out CharacterInfo _pl))
        // {
        //     _pl.GetDamage(DamageReturn());
        // }
    }
}
