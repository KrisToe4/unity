﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private Text m_scoreText;

	// Use this for initialization
	void Start () {
        m_scoreText = GetComponent<Text>();
        m_scoreText.text = ScoreKeeper.score.ToString();
	}
}
