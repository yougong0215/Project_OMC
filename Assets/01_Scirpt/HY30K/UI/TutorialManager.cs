using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    public GameObject[] popUps;
    [HideInInspector] public int popUpIndex;

    public static TutorialManager Instance;

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
        playerInput.InputAction.Player.Disable();
    }
}
