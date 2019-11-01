using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PausedEvent = false;

    public GameObject PausedUI;
    public GameObject OptionsUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausedEvent)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Resume()
    {
        PausedUI.SetActive(false);
        Time.timeScale = 1f;
        PausedEvent = false;
    }

    void Paused()
    {
        PausedUI.SetActive(true);
        Time.timeScale = 0f;
        PausedEvent = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game....");
        Application.Quit();
    }

    public void OptionsMenu()
    {
        Time.timeScale = 0f;
        PausedUI.SetActive(false);
        OptionsUI.SetActive(true);
    }
}
