using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioClip bgm;
    [SerializeField] Slider slider;

    private void Start()
    {
        //bgm = GetComponent<AudioClip>();

        SoundPlay(bgm);
    }
    private void Update()
    {
        AudioSettingSetting();
    }

    public void SoundPlay(AudioClip bgm)
    {
        SoundManager.Instance.PlayBGM(bgm);
    }

    public void AudioSettingSetting()
    {
        SoundManager.Instance.MixerSave(SoundSetting.background, slider.value);
    }
}
