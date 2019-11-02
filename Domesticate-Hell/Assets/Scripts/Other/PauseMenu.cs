// J & Ishan 2019
// Domesticate Hell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PausedEvent = false;

    [SerializeField]
    private GameObject PausedUI;


    void Awake()
    {
        PausedUI.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
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
        HellishTime.PauseTime = false;
        Time.timeScale = 1f;
        PausedEvent = false;
    }

    void Paused()
    {
        PausedUI.SetActive(true);
        HellishTime.PauseTime = true;
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options");
    }
}
