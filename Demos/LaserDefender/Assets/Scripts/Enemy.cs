using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private LaserCannon m_laserCannon;

	// Use this for initialization
	void Start ()
    {
        m_laserCannon = GetComponent<LaserCannon>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float fireRNG = Random.Range(-0.5f, 0.5f);

        if ((m_laserCannon.CurrentRecharge + fireRNG) <= 0)
        {
            m_laserCannon.FireLaser();
        }
    }
}
