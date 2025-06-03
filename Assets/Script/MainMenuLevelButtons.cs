using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuLevelButtons : MonoBehaviour
{

    public void SelectLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
