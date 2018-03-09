using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{


    public void LoadLevel(string name)
    {
        Debug.Log("LoadLevel called for: " + name);

        Brick.DestructibleBrickCount = 0;
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        Brick.DestructibleBrickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");

        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.DestructibleBrickCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
