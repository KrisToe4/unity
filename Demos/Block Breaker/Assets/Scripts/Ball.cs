using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector3 m_paddleToBallVector;
    private bool m_ballStuck;

    private Rigidbody2D m_rigidBody;
    private AudioSource m_AudioSource;
    private Paddle m_paddle;

    // Use this for initialization
    void Start () {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();

        m_paddle = GameObject.FindObjectOfType<Paddle>();

        m_paddleToBallVector = this.transform.position - m_paddle.transform.position;
        m_ballStuck = true;
    }

    void Update()
    {
        if (m_ballStuck)
        {
            this.transform.position = m_paddle.transform.position + m_paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                m_ballStuck = false;
                m_rigidBody.velocity = new Vector2(2.0f, 10f);
            }
        }
    }
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!m_ballStuck)
        {
            m_AudioSource.Play();

            Vector2 velocityTweak;

            if (collision.gameObject.name != "Paddle")
            {
                velocityTweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            }
            else
            {
                velocityTweak = new Vector2(0f, Random.Range(0f, 0.6f));
            }


            m_rigidBody.velocity += velocityTweak;
        }
    }
}
