using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControlManager : MonoBehaviour
{
    private void Start()
    {
        EnableSound();
    }

    public void EnableSound()
    {
        PlayerPrefs.SetInt("soundStatus", 1);
    }

    public void DisableSound()
    {
        PlayerPrefs.SetInt("soundStatus", 0);
    }
}
