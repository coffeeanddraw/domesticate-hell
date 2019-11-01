// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/
// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGuard : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "";
  
    public void SwitchScene()
    { 
        SceneManager.LoadScene(sceneName);
    }
}
