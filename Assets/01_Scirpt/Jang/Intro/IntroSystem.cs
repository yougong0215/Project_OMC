using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class IntroSystem : MonoBehaviour
{
    [SerializeField] private Image blackPanel;
    [SerializeField] private string nextSceneName;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            blackPanel.DOFade(1, 1f).SetEase(Ease.OutCubic).OnComplete(() => 
            {
                SceneManager.LoadScene(nextSceneName);
            });
        }
    }
}
