using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Defender : MonoBehaviour {

    

    private GameObject m_currentTarget;
    private Animator m_animator;

    // Use this for initialization
    void Start ()
    {
        m_animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_currentTarget != null)
        {
            m_animator.SetBool("IsAttacking", true);
        }
        else
        {
            m_animator.SetBool("IsAttacking", false);
        }
    }

    public void SetCurrentTarget(GameObject target)
    {
        m_currentTarget = target;
    }

    public void HitCurrentTarget(int damage)
    {
        if (m_currentTarget != null)
        {
            m_currentTarget.GetComponent<AgentHealth>().TakeDamage(damage);
        }
    }
}
