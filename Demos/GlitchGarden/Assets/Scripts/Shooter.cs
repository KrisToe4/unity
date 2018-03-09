using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class Shooter : MonoBehaviour {

    public GameObject ProjectilePrefab;
    public GameObject Gun;

    private Transform m_projectileContainer;
    private AttackerSpawner m_spawnerInLane;

    private Animator m_animator;

    // Use this for initialization
    void Start () {
        GameObject projectiles = GameObject.Find("Projectiles");
        if (projectiles == null)
        {
            projectiles = new GameObject("Projectiles");
        }
        m_projectileContainer = projectiles.transform;

        m_animator = GetComponent<Animator>();

        SetLaneSpawner();
	}

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerAheadInLane() && !m_animator.GetBool("IsAttacking"))
        {
            m_animator.SetBool("IsFiring", true);
        }
        else
        {
            m_animator.SetBool("IsFiring", false);
        }
    }

    private void Fire()
    {
        if (m_projectileContainer != null)
        {
            GameObject projectile = Instantiate(ProjectilePrefab);
            projectile.transform.parent = m_projectileContainer;
            projectile.transform.position = Gun.transform.position;
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = GameObject.FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner curSpawner in spawners)
        {
            if (curSpawner.transform.position.y == gameObject.transform.position.y)
            {
                m_spawnerInLane = curSpawner;
                return;
            }
        }
    }

    private bool IsAttackerAheadInLane()
    {
        if ((m_spawnerInLane != null) || (m_spawnerInLane.transform.childCount > 0))
        {
            foreach (Transform attacker in m_spawnerInLane.transform)
            {
                if (attacker.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
