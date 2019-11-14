// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipPanel : MonoBehaviour
{
    [SerializeField]
    private string sceneToSkipTo = "";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneToSkipTo);
    }
}
