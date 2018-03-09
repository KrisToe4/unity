using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Defender))]
public class Chicken : MonoBehaviour
{
    public int damage = 1;

    private Defender m_defenderScript;

    // Use this for initialization
    void Start()
    {
        m_defenderScript = GetComponent<Defender>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;

        if (otherObject.GetComponent<Attacker>() != null)
        {
            m_defenderScript.SetCurrentTarget(otherObject);
        }
    }
}
