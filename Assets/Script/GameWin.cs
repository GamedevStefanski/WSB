using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectWatcher : MonoBehaviour
{
    [Tooltip("Nazwa obiektu do monitorowania")]
    public string objectNameToWatch;

    [Tooltip("UI Text lub Panel do pokazania po znikniêciu obiektu")]
    public GameObject uiTextToShow;

    [Tooltip("Nazwa sceny do za³adowania po naciœniêciu R")]
    public string sceneToLoad = "MainScene";

    private GameObject watchedObject;
    private bool isGamePaused = false;

    void Start()
    {
        watchedObject = GameObject.Find(objectNameToWatch);
        if (uiTextToShow != null)
        {
            uiTextToShow.SetActive(false); // Ukryj na start
        }
    }

    void Update()
    {
        if (!isGamePaused)
        {
            if (watchedObject == null)
            {
                PauseGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResumeAndReloadScene();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pauza
        isGamePaused = true;

        if (uiTextToShow != null)
        {
            uiTextToShow.SetActive(true);
        }
    }

    private void ResumeAndReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);
    }
}
