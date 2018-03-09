using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int DestructibleBrickCount;

    public AudioClip CrackClip;
    public Sprite[] brickSprites;

    private bool m_isBreakable;
    private int m_curHits;

    private LevelManager m_levelManager;

    void Awake()
    {
        m_isBreakable = (this.tag == "Breakable");

        if (m_isBreakable)
        {
            Brick.DestructibleBrickCount++;
        }
    }

	// Use this for initialization
	void Start () {
        m_curHits = 0;	

        m_levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (m_isBreakable)
        {
            HandleHit();
        }

        AudioSource.PlayClipAtPoint(CrackClip, gameObject.transform.position);
    }

    private void HandleHit()
    {
        m_curHits++;

        if (m_curHits > brickSprites.Length)
        {
            Brick.DestructibleBrickCount--;
            m_levelManager.BrickDestroyed();

            SmokeGenerator.TriggerSmoke(gameObject);
            Destroy(gameObject);
        }
        else
        {
            LoadNextSprite();
        }
    }

    private void LoadNextSprite()
    {
        if ((m_curHits >= 0) && (m_curHits <= brickSprites.Length) && (brickSprites[m_curHits - 1] != null))
        {
            this.GetComponent<SpriteRenderer>().sprite = brickSprites[m_curHits - 1];
        }
        else
        {
            Debug.LogError("Missing Brick Sprite");
        }

    }
}
