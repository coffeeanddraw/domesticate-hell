///////////////////////////////////
///// ⚔🦂🐾BAT GIRL🐾🦂⚔ /////
///////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGuard : MonoBehaviour
{
    [SerializeField]
    string sceneName = "";
   
    void Update()
    {
        if (Input.GetButtonDown("Interact") || Input.GetButton("Interact"))
        {
            SwitchScene();
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
