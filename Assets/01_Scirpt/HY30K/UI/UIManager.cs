using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject SettingBlur;
    [SerializeField] private CanvasGroup GameOverBlur;
    public bool isGameOver = false;
    public bool isOpen = false;

    private void Awake()
    {
        Instance = this;


        playerInput.ESCBtn += PanelSetting;
    }
    
    

    private void Start()
    {
        SettingBlur.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Restart();
            }
        }
    }

    private void PanelSetting()
    {
        //Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;

        if (isOpen == false)
        {
            //Time.timeScale = 0f;
                        if(SettingBlur != null)
            SettingBlur.SetActive(true);
            isOpen = true;
            CameraManager.Instance.CursorManaging(false);
            playerInput.InputAction.Player.Disable();
        }
        else if (isOpen == true)
        {
            //Time.timeScale = 1f;
            if(SettingBlur != null)
            SettingBlur.SetActive(false);
            isOpen = false;
            CameraManager.Instance.CursorManaging(true);
            playerInput.InputAction.Player.Enable();
        }
    }

    public void PanelGameOver()
    {
        isGameOver = true;
        GameOverBlur.DOFade(1, 2);
    }

    public void Close()
    {
        PanelSetting();
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        isGameOver = false;
    }
}
