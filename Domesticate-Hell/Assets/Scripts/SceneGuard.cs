using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGuard : MonoBehaviour
{
    [SerializeField]
    string sceneName = "";
   
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
