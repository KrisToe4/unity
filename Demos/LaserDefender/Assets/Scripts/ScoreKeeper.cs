using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public Text scoreText;
    public static int score = 0;

    void Start()
    {
        Reset();
    }

    public void ScorePoints(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}
