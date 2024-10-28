
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startImage;

    [SerializeField]
    private GameObject correctImage, incorrectImage;

    [SerializeField]
    private Text questionText, firstResultText, secondResultText, thirdResultText;

    [SerializeField]
    private Text correctCountText, incorrectCountText, scoreText;

    string whichGame;

    int firstMultiplier;
    int secondMultiplier;

    int correctResult;
    int firstWrongResult;
    int secondWrongResult;

    public int correctCount, incorrectCount, totalScore;

    PlayerManager playerManager;

    //AdmobManager admobManager;


    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerManager>();
        //admobManager = Object.FindObjectOfType<AdmobManager>();
    }

    void Start()
    {
        correctCount = 0;
        incorrectCount = 0;
        totalScore = 0;

        correctImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        incorrectImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (PlayerPrefs.HasKey("whichGame"))
        {
            whichGame = PlayerPrefs.GetString("whichGame");
            Debug.Log("player pref bulundu " + whichGame.ToString());
        }

        StartCoroutine(StartTextRoutine());
    }

    IEnumerator StartTextRoutine()
    {
        startImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        startImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        startImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);

        StartGame();
    }

    void StartGame()
    {
        playerManager.shouldRotate = true;
        DisplayQuestion();

        //admobManager.ShowBanner();
    }

    void SetFirstMultiplier()
    {
        switch (whichGame)
        {
            case "two":
                firstMultiplier = 2;
                break;

            case "three":
                firstMultiplier = 3;
                break;

            case "four":
                firstMultiplier = 4;
                break;

            case "five":
                firstMultiplier = 5;
                break;

            case "six":
                firstMultiplier = 6;
                break;

            case "seven":
                firstMultiplier = 7;
                break;

            case "eight":
                firstMultiplier = 8;
                break;

            case "nine":
                firstMultiplier = 9;
                break;

            case "ten":
                firstMultiplier = 10;
                break;

            case "mixed":
                firstMultiplier = Random.Range(2, 11);
                break;
        }
    }

    void DisplayQuestion()
    {
        SetFirstMultiplier();

        secondMultiplier = Random.Range(2, 11);

        int randomValue = Random.Range(1, 100);

        if (randomValue <= 50)
        {
            questionText.text = firstMultiplier.ToString() + "x" + secondMultiplier.ToString();
        }
        else
        {
            questionText.text = secondMultiplier.ToString() + "x" + firstMultiplier.ToString();
        }

        correctResult = firstMultiplier * secondMultiplier;

        DisplayResults();
    }

    void DisplayResults()
    {
        firstWrongResult = correctResult + Random.Range(2, 10);

        if (correctResult > 10)
        {
            secondWrongResult = correctResult - Random.Range(2, 8);
        }
        else
        {
            secondWrongResult = Mathf.Abs(correctResult - Random.Range(1, 5));
        }

        int randomValue = Random.Range(1, 100);

        if (randomValue <= 33)
        {
            firstResultText.text = correctResult.ToString();
            secondResultText.text = firstWrongResult.ToString();
            thirdResultText.text = secondWrongResult.ToString();

        }
        else if (randomValue <= 66)
        {
            secondResultText.text = correctResult.ToString();
            firstResultText.text = firstWrongResult.ToString();
            thirdResultText.text = secondWrongResult.ToString();
        }
        else
        {
            thirdResultText.text = correctResult.ToString();
            secondResultText.text = firstWrongResult.ToString();
            firstResultText.text = secondWrongResult.ToString();
        }
    }

    public void CheckResult(int resultText)
    {
        correctImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        incorrectImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (resultText == correctResult)
        {
            correctCount++;
            totalScore += 20;
            correctImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }
        else
        {
            incorrectCount++;
            incorrectImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }

        correctCountText.text = correctCount.ToString() + " CORRECT";
        incorrectCountText.text = incorrectCount.ToString() + " INCORRECT";
        scoreText.text = totalScore.ToString() + " SCORE";

        DisplayQuestion();
    }
}