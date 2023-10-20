using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{
    
    private PlayerMain _inputAction;
    public PlayerMain InputAction => _inputAction;

    public event Action<Vector2> OnMovement;

    public event Action OnSpace;
    public event Action OnLeftClick;
    public event Action OnContrl;
    public event Action OnShift; 
    
    private void Awake()
    {
        _inputAction = new PlayerMain();
        
        _inputAction.Player.Enable();
        _inputAction.Player.Jump.performed += SpaceHandle;
        _inputAction.Player.MouseLeftClick.performed += LeftClickHandle;
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
        Vector2 inputDir = _inputAction.Player.Movement.ReadValue<Vector2>();
        OnMovement?.Invoke(inputDir);
    }
}