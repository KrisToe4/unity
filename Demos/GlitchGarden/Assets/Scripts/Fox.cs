using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    public int damage = 1;

    private Attacker m_attackerScript;
    private Animator m_animator;

    // Use this for initialization
    void Start()
    {
        m_attackerScript = GetComponent<Attacker>();
        m_animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;

        if (otherObject.GetComponent<Defender>() != null)
        {
            if (otherObject.GetComponent<Gravestone>() != null)
            {
                Jump();
            }
            else
            {
                m_attackerScript.SetCurrentTarget(otherObject);
            }
        }
    }

    private void Jump()
    {
        m_animator.SetTrigger("Jump");
    }
}
