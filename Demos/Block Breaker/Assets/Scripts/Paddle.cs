using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float paddleHeight = 8.0f;
    public bool autoPlay = false;

    private float m_mousePosInBlocks;
    private Vector3 m_paddlePos;

    private Ball m_ball;

    // Use this for initialization
    void Start () {
        m_ball = GameObject.FindObjectOfType<Ball>();

        m_paddlePos = new Vector3(0.0f, paddleHeight, 0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            FollowMouse();
        }
        else
        {
            FollowBall();
        }
    }

    private void FollowMouse()
    {
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16;
        m_paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        this.transform.position = m_paddlePos;
    }

    private void FollowBall()
    {
        Vector2 ballPos = m_ball.transform.position;
        m_paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        this.transform.position = m_paddlePos;
    }
}
