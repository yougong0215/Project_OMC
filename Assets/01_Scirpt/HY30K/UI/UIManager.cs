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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerInput.ESCBtn += PanelSetting;
    }

    private void Start()
    {
        SettingBlur.SetActive(false);
    }

    void Update()
    {

        if (isGameOver == true)
        {
            PanelGameOver();
        }
    }

    private void PanelSetting()
    {
        //Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;

        if (isOpen == false)
        {
            //Time.timeScale = 0f;
            SettingBlur.SetActive(true);
            isOpen = true;
            CameraManager.Instance.CursorManaging(false);
            playerInput.InputAction.Player.Disable();
        }
        else if (isOpen == true)
        {
            //Time.timeScale = 1f;
            SettingBlur.SetActive(false);
            isOpen = false;
            CameraManager.Instance.CursorManaging(true);
            playerInput.InputAction.Player.Enable();
        }
    }

    public void PanelGameOver()
    {
        GameOverBlur.DOFade(1, 2);

        if (Input.anyKeyDown)
        {
            Restart();
        }
    }

    public void Close()
    {
        PanelSetting();
    }

    public void Restart()
    {
        isGameOver = false;
        SceneManager.LoadScene("MainScene");
    }
}
