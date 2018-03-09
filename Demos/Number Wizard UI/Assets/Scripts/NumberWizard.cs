using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NumberWizard : MonoBehaviour {

    int min;
    int max;

    int currentGuess;

    public int maxGuesses = 5;
    public Text GuessString;

    void Start() {
        StartGame();
    }

    private void StartGame()
    {
        min = 1;
        max = 1001;

        currentGuess = Random.Range(min, max);
        GuessString.text = "Is your number " + currentGuess.ToString() + "?";
    }

    private void UpdateGuess()
    {
        currentGuess = Random.Range(min, max);
        maxGuesses--;

        if (maxGuesses <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
        else
        {
            GuessString.text = "Is your number " + currentGuess.ToString() + "?";
        }
    }

    public void GuessHigher()
    {
        min = currentGuess;
        UpdateGuess();
    }

    public void GuessLower()
    {
        max = currentGuess;
        UpdateGuess();
    }
}
