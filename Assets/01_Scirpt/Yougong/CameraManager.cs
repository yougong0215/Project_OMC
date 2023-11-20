using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
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

    public void CursorManaging(bool value)
    {
        if (value)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private Coroutine _shake;
    private Coroutine _scale;
    private float _shakeIntensity = 0;
    private float _shakeTime=0;
    private float _curtime = 0;

    public void ScaleBind(float _time = 0.02f, float _amp = 0.2f)
    {
        if (_scale != null)
            _scale = null;
        _scale = StartCoroutine(Scale(_time, _amp));
    }

    IEnumerator Scale(float _time = 0.02f, float _amp = 0.2f)
    {
        Time.timeScale = _amp;
        yield return new WaitForSeconds(_time);
        Time.timeScale = 1;
    }

    public void Shakeing(float shakeIntensity = 5f, float shakeTiming = 0.5f)
    {
        if (_shake != null)
            _shake = null;
        _shakeIntensity = shakeIntensity;
        _shakeTime = shakeTiming;
        _curtime = shakeTiming;
        //_shake = StartCoroutine(_ProcessShake(shakeIntensity, shakeTiming));
    }

    private void Update()
    {
        _curtime -= Time.deltaTime;
        if (_curtime > 0)
        {
            Noise(_shakeIntensity);
        }
        else if(_shakeIntensity != 0)
        {
            _shakeIntensity = 0;
            Noise(0);
        }
    }

    private void Noise(float amplitudeGain)
    {
        if (Vcam == null)
            return;
        
        Cinemachine.CinemachineBasicMultiChannelPerlin _cin =
            Vcam._currentCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        _cin.m_AmplitudeGain = amplitudeGain;
        _cin.m_FrequencyGain = amplitudeGain;
 
    }
    
}
