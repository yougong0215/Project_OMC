using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator fadeAnime;
    [SerializeField] private PlayerInput playerInput;
    public static SceneController Instance;

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

    public void MoveLevel()
    {
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        fadeAnime.SetTrigger("In");
        yield return new WaitForSeconds(1);
        playerInput.InputAction.Player.Enable();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        fadeAnime.SetTrigger("Out");
    }
}
