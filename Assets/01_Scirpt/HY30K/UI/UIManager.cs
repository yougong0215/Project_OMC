using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput playerInput;
    public bool isOpen = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen == true)
            {
                animator.SetTrigger("blurIn");
            }
            else if (isOpen == false)
            {
                animator.SetTrigger("blurOut");
            }
        }
    }
    private void In()
    {
        
    }
    public void SettingClose()
    {
        playerInput.InputAction.Player.Disable();
        //animator.SetTrigger("panelUp");
    }

    public void SettingOpen()
    {
        playerInput.InputAction.Player.Enable();
        //animator.SetTrigger("panelDown");
    }
}
