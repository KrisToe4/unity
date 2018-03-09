using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {

    public static GameObject selectedDefender;

    public GameObject DefenderPrefab;
    public int StarCost = 10;

    private SpriteRenderer m_spriteRenderer;
    private DefenderButton[] m_defenderButtons;

	// Use this for initialization
	void Start () {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_defenderButtons = FindObjectsOfType<DefenderButton>();
	}

    void Update()
    {
        if ((selectedDefender == gameObject) && (DefenderSpawner.CurrentStarCount < StarCost))
        {
            m_spriteRenderer.color = Color.black;
            selectedDefender = null;
        }
    }

    void OnMouseDown()
    {
        foreach (DefenderButton button in m_defenderButtons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }
        m_spriteRenderer.color = Color.white;
        selectedDefender = gameObject;
    }
}
