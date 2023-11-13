using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("µÙ∑π¿Ã Ω√∞£")] [SerializeField] private int Time = 0;
    public GameObject[] popUps;
    private Animator animator;
    [HideInInspector] public int popUpIndex;

    public static TutorialManager Instance;

    private void Awake()
    {
        animator = GetComponent<Animator>();

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

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IndexUp();
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                IndexUp();
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                IndexUp();
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R))
            {
                IndexUp();
            }
        }
        else if (popUpIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetTrigger("down");
            }
        }
    }

    public void IndexUp()
    {
        popUpIndex++;
    }

    private IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(Time);
    }
}
