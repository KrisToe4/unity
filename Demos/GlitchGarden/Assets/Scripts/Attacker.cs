using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [Tooltip ("Frequency in seconds (avg) to spawn")]
    public float spawnFrequency;

    private GameObject m_currentTarget;
    private Animator m_animator;
    private float m_currentSpeed;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * m_currentSpeed * Time.deltaTime);

        if (m_currentTarget != null)
        {
            m_animator.SetBool("IsAttacking", true);
        }
        else
        {
            m_animator.SetBool("IsAttacking", false);
        }
	}

    public void SetSpeed(float speed)
    {
        m_currentSpeed = speed;
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
