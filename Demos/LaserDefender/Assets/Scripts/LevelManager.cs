using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

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

    public void LoadLevel(string name)
    {
        Debug.Log("LoadLevel called for: " + name);

        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");

        Application.Quit();
    }
}
