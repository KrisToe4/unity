using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager m_levelManager;

    void Start()
    {
        m_levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.ToString());

        if (collider.gameObject.name == "Ball")
        {
            m_levelManager.LoadLevel("Lose");
        }
    }
}
