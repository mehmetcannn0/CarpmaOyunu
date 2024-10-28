using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClick;

    [SerializeField]
    private GameObject soundPanel;

    private bool isSoundPanelOpen;

    void Start()
    {
        isSoundPanelOpen = false;
        soundPanel.GetComponent<RectTransform>().localPosition = new Vector3(-19, -13, 0);

        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void SwitchToSecondLevel()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        SceneManager.LoadScene("SecondMenuLevel");
    }

    public void ToggleSettings()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        if (!isSoundPanelOpen)
        {
            soundPanel.GetComponent<RectTransform>().DOLocalMoveY(90, 0.5f);
            isSoundPanelOpen = true;
        }
        else
        {
            soundPanel.GetComponent<RectTransform>().DOLocalMoveY(-13, 0.5f);
            isSoundPanelOpen = false;
        }
    }

    public void QuitGame()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        Application.Quit();
    }
}
