using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleRotateManager : MonoBehaviour
{
    string result;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }

            if (gameObject.name == "LeftCircle")
            {
                result = GameObject.Find("LeftText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "CenterCircle")
            {
                result = GameObject.Find("CenterText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "RightCircle")
            {
                result = GameObject.Find("RightText").GetComponent<Text>().text;
            }
            Debug.Log("res " +result);
            gameManager.CheckResult(int.Parse(result));
        }
    }
}
