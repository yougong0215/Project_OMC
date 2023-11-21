using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
//using LitJson;
using UnityEditor.VersionControl;
//using UnityEngine.Purchasing.MiniJSON;


public enum SoundSetting
{
    Master,
    background,
    SFX,
    UISound,

}

public class SoundJson
{
    public float Master = 50.0f;
    public float SFX= 50.0f;
    public float UI= 50.0f;
    public float BGM= 50.0f;
}

public class SoundManager : Singleton<SoundManager>
{

    [SerializeField] private AudioSource _backgroundSound;
    public AudioMixer _mixer;

    private SoundJson _data;

    private void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
        SoundJson savedata = new SoundJson();
        try
        {
            string path = Path.Combine(Application.dataPath, "playerData.json");
            string jsonData = File.ReadAllText(path);
            savedata = JsonUtility.FromJson<SoundJson>(jsonData);
            Debug.LogWarning("성공");
        }
        catch
        {
            string jsonData = JsonUtility.ToJson(savedata);
            string path = Path.Combine(Application.dataPath, "playerData.json");
            File.WriteAllText(path, jsonData);
            Debug.LogWarning("첫실행 or 그냥 애러");
        }


        _data = savedata;
        
        print(savedata.Master);
        MixerSave(SoundSetting.Master, _data.Master);
        MixerSave(SoundSetting.background, _data.BGM);
        MixerSave(SoundSetting.UISound, _data.UI);
        MixerSave(SoundSetting.SFX,_data.SFX);
    }

    public void MixerSave(SoundSetting ss, float value)
    {
        //value = Mathf.RoundToInt(value);
        if (value<= .0f)
        {
            _mixer.SetFloat(ss.ToString(), -80f);
        }
        else
        {
            _mixer.SetFloat(ss.ToString(), Mathf.Lerp(-40,0, value));
        }
        switch (ss)
        {
            case SoundSetting.Master:
                _data.Master = value;
                break;
            case SoundSetting.UISound:
                _data.UI = value;
                break;
            case SoundSetting.SFX:
                _data.SFX = value;
                break;
            case SoundSetting.background:
                _data.BGM = value;
                break;
            default:
                break;
        }
        
        
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = JsonUtility.ToJson(_data);
        File.WriteAllText(path, jsonData);
        
        Debug.LogWarning($"VOLUM SET : {value}");
    }

    public float GetValue(SoundSetting ss)
    {
        switch (ss)
        {
            case SoundSetting.Master:
                return _data.Master;
                case SoundSetting.UISound:
                    return _data.UI;
                case SoundSetting.SFX:
                    return _data.SFX;
                case SoundSetting.background:
                    return _data.BGM;
                default:
                    break;
        }

        return _data.Master;
    }
    
    
    public void PlaySFX(AudioClip _soundType)
    {
        GameObject bg = Instantiate(new GameObject());
        _backgroundSound = bg.AddComponent<AudioSource>();

        AudioMixerGroup[] _ad = _mixer.FindMatchingGroups("SFX");
        _backgroundSound.outputAudioMixerGroup = _ad[0];

        _backgroundSound.clip = _soundType;
        _backgroundSound.Play();
    }

    public void SceneLoadDestory()
    {
        AudioSource[] ad = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource s in ad)
        {
            if (s.isPlaying)
            {
                s.Stop();
            }
            Destroy(s);
        }
    }
    public void PlayBGM(AudioClip _bgType)
    {
        if (_backgroundSound != null)
        {
            _backgroundSound.Stop();

            Destroy(_backgroundSound.gameObject);
        }

        
        GameObject bg = Instantiate(new GameObject());
        
        //DontDestroyOnLoad(bg);
        _backgroundSound = bg.AddComponent<AudioSource>();
        AudioMixerGroup[] _ad = _mixer.FindMatchingGroups("background");
        _backgroundSound.outputAudioMixerGroup = _ad[0];
        _backgroundSound.clip = _bgType;
        _backgroundSound.Play();
    }
}
