using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log("LoadLevel called for: " + name);

        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");

        Application.Quit();
    }

    public void NextGuess(bool GuessHigher)
    {

    }
}
