using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {

    public int damage = 1;

    private Attacker m_attackerScript;

	// Use this for initialization
	void Start ()
    {
        m_attackerScript = GetComponent<Attacker>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;

        if (otherObject.GetComponent<Defender>() != null)
        {
            m_attackerScript.SetCurrentTarget(otherObject);
        }
    }
}
