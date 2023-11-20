using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillBtn
{
    Q,E,R
}

public class PlayerCanvasM : MonoBehaviour
{
    [Header("Skill_Img")]
    public Image _q_image;
    public Image _e_image;
    public Image _r_image;
    
    //public Image


    public void SetSkillIcon(SkillBtn sk, Sprite tm)
    {
        switch (sk)
        {
            case SkillBtn.Q:
                if (tm != null)
                {
                    _q_image.sprite = tm;
                    
                    _q_image.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    _q_image.sprite = null;
                    _q_image.color = new Color(1,1,1, 0);
                }

                break;
            case SkillBtn.E:
                if (tm != null)
                {
                    _e_image.sprite = tm;
                    _e_image.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    _e_image.sprite = null;
                    _e_image.color = new Color(1,1,1, 0);
                }
                break;
            case SkillBtn.R:
                if (tm != null)
                {
                    _r_image.sprite = tm;
                    _r_image.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    _r_image.sprite = null;
                    _r_image.color = new Color(1, 1, 1, 0);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sk), sk, null);
        }
    }
}
