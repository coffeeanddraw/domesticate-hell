using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject PausedUI;

    public GameObject OptionsUI;

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void GoBack()
    {
        Time.timeScale = 0f;
        OptionsUI.SetActive(false);
        PausedUI.SetActive(true);
    }
}
