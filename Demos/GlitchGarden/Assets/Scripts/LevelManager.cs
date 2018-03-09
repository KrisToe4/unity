using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float autoLoadNextLevelTimer;

    void Awake()
    {
        if (LevelManager.instance == null)
        {
            LevelManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (autoLoadNextLevelTimer > 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelTimer);
        }
        else
        {
            Debug.Log("Autoload disabled for current scene");
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("LoadLevel called for: " + name);

        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        MusicManager musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager != null)
        {
            musicManager.UpdateVolume(PlayerPrefManager.MasterVolume);
        }
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");

        Application.Quit();
    }
}
