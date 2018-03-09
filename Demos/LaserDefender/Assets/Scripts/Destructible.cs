using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public int maxHealth = 1;
    public int scoreValue = 150;

    public AudioClip deathSound;

    private int m_health;
    private bool m_invincible;

    private ScoreKeeper m_scoreKeeper;

    // Use this for initialization
    void Start () {
        m_health = maxHealth;

        if (gameObject.GetComponent<SelfDestruct>() == null)
        {
            gameObject.AddComponent<SelfDestruct>();
        }
        m_scoreKeeper = LevelManager.instance.GetComponent<ScoreKeeper>();

        m_invincible = true;
        Invoke("RemoveSpawnInvincibility", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(int damage)
    {
        if (!m_invincible)
        {
            m_health -= damage;
            if (m_health <= 0)
            {
                Die();
            }
        }
    }

    private void RemoveSpawnInvincibility()
    {
        m_invincible = false;
    }

    private void Die()
    {
        gameObject.GetComponent<SelfDestruct>().Trigger();
        m_scoreKeeper.ScorePoints(scoreValue);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }
}
