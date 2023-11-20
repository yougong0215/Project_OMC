using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillBtn
{
    Left,Q,E,R
}
public class PlayerCanvasM : MonoBehaviour
{
    [Header("Skill_Img")] public Image _left_image;
    public Image _q_image;
    public Image _e_image;
    public Image _r_image;
    [Header("Cooldown")]public Image _left_cool;
    public Image _q_cool;
    public Image _e_cool;
    public Image _r_cool;

    public void SkillCooldown(SkillBtn bn, float MaxCool, float curCool)
    {
        
        if (curCool <= 0)
        {
            switch (bn)
            {
                case SkillBtn.Left:
                {
                    _left_cool.fillAmount = 0;
                    _left_image.color = new Color(1,1,1,0);
                }
                    break;
                case SkillBtn.Q:
                    _q_cool.fillAmount = 0;
                    _q_image.color = Color.white;
                    break;
                case SkillBtn.E:
                    _e_cool.fillAmount = 0;
                    _e_image.color = Color.white;
                    break;
                case SkillBtn.R:
                    _r_cool.fillAmount = 0;
                    _r_image.color = Color.white;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(bn), bn, null);
            }

            return;
        }
//        Debug.LogWarning($"Cool = {curCool / MaxCool}");
        switch (bn)
        {
            case SkillBtn.Left:
            {
                _left_cool.fillAmount = Mathf.Lerp(0, 1, curCool / MaxCool);
                _left_image.color = new Color(0.8f,0.8f,0.8f,0.5f);
            }
                break;
            case SkillBtn.Q:
                _q_cool.fillAmount = Mathf.Lerp(0, 1, curCool / MaxCool);
                _q_image.color = Color.gray;
                break;
            case SkillBtn.E:
                _e_cool.fillAmount = Mathf.Lerp(0, 1, curCool / MaxCool);
                _e_image.color = Color.gray;
                break;
            case SkillBtn.R:
                _r_cool.fillAmount = Mathf.Lerp(0, 1, curCool / MaxCool);
                _r_image.color = Color.gray;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(bn), bn, null);
        }
    }
    
    public void SetSkillIcon(SkillBtn sk, Sprite tm)
    {
        switch (sk)
        {
            case SkillBtn.Left:
                _left_cool.fillAmount = 0;
                _q_image.color = new Color(1,1,1, 1);
                if (tm != null)
                    _left_image.sprite = tm;
                else
                {
                    _left_image.sprite = null;
                    
                }
                break;
            case SkillBtn.Q:
                _q_cool.fillAmount = 0;
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
                _e_cool.fillAmount = 0;
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
                _r_cool.fillAmount = 0;
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
