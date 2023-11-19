using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitDissolve : MonoBehaviour
{
    [SerializeField] private List<SkinnedMeshRenderer> _skin = new();
    [SerializeField] private List<MaterialPropertyBlock> _blocks = new();
   
    private readonly int _blinkHash = Shader.PropertyToID("_Blink");

    private float _currentTime = 0;
    private void Awake()
    {
        Reserch();
    }

    public void Reserch()
    {
        _blocks.Clear();
        _skin.Clear();
        
        _skin = GetComponentsInChildren<SkinnedMeshRenderer>().ToList();
        for(int i =0; i < _skin.Count; i++)
        {
            _blocks.Add(new MaterialPropertyBlock());
            _skin[i].GetPropertyBlock(_blocks[i]);
        }
    }

    public void StartHiting(float _b = 0.5f)
    {
        StartCoroutine(MaterialBlink(_b));
    }

    IEnumerator MaterialBlink(float _blinkTime = 0.5f)
    {
        _currentTime = _blinkTime;
        for (int i = 0; i < _skin.Count(); i++)
        {
            _blocks[i].SetFloat(_blinkHash, 0.5f);
            _skin[i].SetPropertyBlock(_blocks[i]);
        }

        yield return new WaitForSeconds(_blinkTime);
        FinishFeedback();
    }

    private void Update()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            
            for (int i = 0; i < _skin.Count(); i++)
            {
                _blocks[i].SetFloat(_blinkHash, _currentTime);
                _skin[i].SetPropertyBlock(_blocks[i]);
            }
        }

    }

    public void FinishFeedback()
    {
        StopAllCoroutines(); //이 비해비어에서 관리하는 모든 코루틴 종료
        for (int i = 0; i < _skin.Count(); i++)
        {
            _blocks[i].SetFloat(_blinkHash, 0f);
            _skin[i].SetPropertyBlock(_blocks[i]);
        }

    }
}
