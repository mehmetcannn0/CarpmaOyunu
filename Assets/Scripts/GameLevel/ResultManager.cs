using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Image resultImage;

    [SerializeField]
    private Text correctText, incorrectText, scoreText;

    [SerializeField]
    private GameObject replayButton, mainMenuButton;

    float timer;
    bool isImageOpening;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        timer = 0;
        isImageOpening = true;

        correctText.text = "";
        incorrectText.text = "";
        scoreText.text = "";

        replayButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        mainMenuButton.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(OpenImageRoutine());
    }

    IEnumerator OpenImageRoutine()
    {
        while (isImageOpening)
        {
            timer += 0.15f;
            resultImage.fillAmount = timer;

            yield return new WaitForSeconds(0.1f);

            if (timer >= 1)
            {
                timer = 1;
                isImageOpening = false;

                correctText.text = gameManager.correctCount.ToString() + " CORRECT";
                incorrectText.text = gameManager.incorrectCount.ToString() + " INCORRECT";
                scoreText.text = gameManager.totalScore.ToString() + " SCORE";

                replayButton.GetComponent<RectTransform>().DOScale(1, 0.3f);
                mainMenuButton.GetComponent<RectTransform>().DOScale(1, 0.3f);
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}