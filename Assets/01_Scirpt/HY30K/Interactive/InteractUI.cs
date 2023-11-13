using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class InteractUI : Interactable
{
    [SerializeField] private GameObject panel;
    [SerializeField] private PlayerInput playerInput;
    private void Start()
    {
        panel.SetActive(false);
    }
    protected override void Interact()
    {
        playerInput.InputAction.Player.Disable();
        Cursor.lockState = CursorLockMode.None;
        panel.SetActive(true);
    }
}
