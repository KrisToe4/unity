using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

    private ParticleSystem m_particleSystem;

	// Use this for initialization
	void Start ()
    {
        m_particleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!m_particleSystem.isEmitting)
        {
            m_particleSystem.Stop();
            SmokeGenerator.SmokeFinished(gameObject);
        }
	}
}
