using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    private Text m_currentStarCount;

	// Use this for initialization
	void Start () {
        m_currentStarCount = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        m_currentStarCount.text = DefenderSpawner.CurrentStarCount.ToString();
	}
}
