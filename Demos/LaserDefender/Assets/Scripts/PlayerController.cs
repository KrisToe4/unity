using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed = 5.0f;
    public float playerPadding = 1f;

    private float m_xMin;
    private float m_xMax;

    private Rigidbody2D m_RigidBody;
    private LaserCannon m_laserCannon;

    // Use this for initialization
    void Start ()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_laserCannon = GetComponent<LaserCannon>();

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        m_xMin = leftmost.x + playerPadding;
        m_xMax = rightmost.x - playerPadding;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Control Code
        m_RigidBody.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_RigidBody.velocity = Vector2.left * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_RigidBody.velocity = Vector2.right * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (m_laserCannon.CurrentRecharge <= 0)
            {
                m_laserCannon.FireLaser();   
            }
            
        }
        
        // Update Code

        // Restrict player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, m_xMin, m_xMax);
        transform.position = new Vector2(newX, transform.position.y);
    }

    void OnDestroy()
    {
        LevelManager.instance.LoadLevel("Score");
    }
}
