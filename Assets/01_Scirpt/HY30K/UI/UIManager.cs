using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject blurImg;
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

    private void Start()
    {
        blurImg.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PanelSetting();
        }
    }

    public void PanelSetting()
    {
        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;

        if (isOpen == false)
        {
            Time.timeScale = 0f;
            blurImg.SetActive(true);
            isOpen = true;
            playerInput.InputAction.Player.Disable();
        }
        else if (isOpen == true)
        {
            Time.timeScale = 1f;
            blurImg.SetActive(false);
            isOpen = false;
            playerInput.InputAction.Player.Enable();
        }
    }

    public void Close()
    {
        blurImg.SetActive(false);
        isOpen = false;
    }
}
