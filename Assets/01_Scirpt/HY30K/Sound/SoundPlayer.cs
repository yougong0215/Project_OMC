using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private SoundSetting _type;
    [SerializeField] AudioClip bgm;
    [SerializeField] Slider slider;

    private void Start()
    {
        //bgm = GetComponent<AudioClip>();
        slider.value = SoundManager.Instance.GetValue(_type);
        if(bgm != null)
            SoundPlay(bgm);
    }

    public void SoundPlay(AudioClip bgm)
    {
        SoundManager.Instance.PlayBGM(bgm);
    }

    public void AudioSettingSetting(float value)
    {
        SoundManager.Instance.MixerSave(_type, value);
    }
}
