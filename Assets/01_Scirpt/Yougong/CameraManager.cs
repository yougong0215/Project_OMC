using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private CameraCollision _Vcam;

    public CameraCollision Vcam
    {
        get
        {
            if (_Vcam == null)
            {
                _Vcam = GameObject.Find("Virtual3rdCam").GetComponent<CameraCollision>();
            }

            return _Vcam;
        }
    }

    private Coroutine _shake;
    private Coroutine _scale;

    public void ScaleBind(float _time = 0.02f, float _amp = 0.08f)
    {
        if (_scale != null)
            _scale = null;
        _scale = StartCoroutine(Scale());
    }

    IEnumerator Scale(float _time = 0.04f, float _amp = 0.2f)
    {
        Time.timeScale = _amp;
        yield return new WaitForSeconds(_time);
        Time.timeScale = 1;
    }

    public void Shakeing(float shakeIntensity = 5f, float shakeTiming = 0.5f)
    {
        if (_shake != null)
            _shake = null;
        
        _shake = StartCoroutine(_ProcessShake(shakeIntensity, shakeTiming));
    }

    private IEnumerator _ProcessShake(float shakeIntensity = 5f, float shakeTiming = 0.5f)
    {
        Noise(shakeIntensity, shakeIntensity);
        yield return new WaitForSeconds(shakeTiming);
        Noise(0, 0);
    }
 
    private void Noise(float amplitudeGain, float frequencyGain)
    {
        if (Vcam == null)
            return;
        
        Cinemachine.CinemachineBasicMultiChannelPerlin _cin =
            Vcam._currentCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        _cin.m_AmplitudeGain = amplitudeGain;
        _cin.m_AmplitudeGain = amplitudeGain;
        _cin.m_AmplitudeGain = amplitudeGain;
            
        _cin.m_FrequencyGain = frequencyGain;
        _cin.m_FrequencyGain = frequencyGain;
        _cin.m_FrequencyGain = frequencyGain;      
 
    }
    
}
