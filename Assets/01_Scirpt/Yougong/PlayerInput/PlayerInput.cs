using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{
    private PlayerMain _inputAction;
    public PlayerMain InputAction => _inputAction;

    public event Action<Vector2> OnMovement;


    public event Action ESCBtn;
    public event Action OnSpace;
    public event Action OnLeftClick;
    public event Action OnContrl;
    public event Action OnShift;
    public event Action OnRightClick;
    
    ////////// Attack Btn

    public event Action Q_Btn;
    public event Action E_Btn;
    public event Action R_Btn;

    public event Action TabBtn; 

    public event Action Interactive_Btn;

    public Vector2 _input;
    
    private void Awake()
    {
        _inputAction = new PlayerMain();
        
        _inputAction.Player.Enable();
        _inputAction.Player.Space.performed += SpaceHandle;
        _inputAction.Player.MouseLeftClick.performed += LeftClickHandle;
        _inputAction.Player.MouseRightClick.performed += RightClickHandle;
        _inputAction.Player.Q_Click.performed += Q_ClickHandle;
        _inputAction.Player.E_Click.performed += E_ClickHandle;
        _inputAction.Player.R_Click.performed += R_ClickHandle;
        _inputAction.Player.Tab.performed += TabHandle;
        _inputAction.Player.ESC.performed += ESCHandle;

    }

    public void SkillInputReset()
    {
        OnLeftClick = null;
        OnRightClick = null;
        Q_Btn = null;
        E_Btn = null;
        R_Btn = null;
    }

    public void ESCHandle(InputAction.CallbackContext obj)
    {
        Debug.Log("ESC");
        ESCBtn?.Invoke();
    }

    public void TabHandle(InputAction.CallbackContext obj)
    {
        TabBtn?.Invoke();
    }

    public void SetInteractive(Action act = null)
    {
        
        Interactive_Btn = act;
    }

    private void R_ClickHandle(InputAction.CallbackContext obj)
    {
        R_Btn?.Invoke();
    }

    private void E_ClickHandle(InputAction.CallbackContext obj)
    {
        E_Btn?.Invoke();
    }

    private void Q_ClickHandle(InputAction.CallbackContext obj)
    {
        Q_Btn?.Invoke();
    }

    private void RightClickHandle(InputAction.CallbackContext obj)
    {
        OnRightClick?.Invoke();
    }

    public void SpaceHandle(InputAction.CallbackContext context)
    {
        OnSpace?.Invoke();
    }

    public void LeftClickHandle(InputAction.CallbackContext context)
    {
        OnLeftClick?.Invoke();
    }

    public void Update()
    {
        _input = _inputAction.Player.Movement.ReadValue<Vector2>();
        OnMovement?.Invoke(_input);
    }

    public Vector2 InputVector()
    {
        return _input;
        
    }
    
    
    
}