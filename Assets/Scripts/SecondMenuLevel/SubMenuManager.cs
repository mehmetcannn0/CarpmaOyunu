using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SubMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject subMenuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClick;

    void Start()
    {
        if (subMenuPanel != null)
        {
            subMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
            subMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        }
    }

    public void WhichGameToOpen(string gameName)
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        PlayerPrefs.SetString("whichGame", gameName);
        SceneManager.LoadScene("GameLevel");
    }

    public void GoBack()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("MenuLevel");
    }
}
