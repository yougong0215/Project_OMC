using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Skill/Teleport")]
public class SkillTeleportSO : SkillSO
{
    [SerializeField] float distance = 5;
    
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


            vec.y = _info.transform.position.y + 0.1f;

            RaycastHit[] ray = Physics.RaycastAll(_info.transform.position + new Vector3(0,1f,0), Cam.transform.forward.normalized, distance*5 );

            bool isCheck = false;
            foreach(var a in ray)
            {
                if (a.transform.gameObject.layer  == 10)
                {

                    Debug.Log($"적이 맞음");
                    _info.transform.position = -a.transform.forward * 2;
                    isCheck =true;
                    break;

                }
                else if (a.transform.gameObject.layer != 9)
                {
                    Debug.Log($"{a.point} {a.collider.name} 맞음!");
                    _info.transform.position = a.point;
                    isCheck =true;
                    break;
                }
            }
            if(isCheck ==false)
                _info.transform.position += vec * 5;
          
            
        }
    }
    
    public override void SkillUpdate()
    {
        
    }
    
    public override void SKillInvoke(Collider cols, bool Damaged = true)
    {
        base.SKillInvoke(cols,false);
        if (cols.TryGetComponent(out CharacterInfo _pl))
        {
            _pl.GetDamage(DamageReturn() * 0.2f);
        }
    }
}
