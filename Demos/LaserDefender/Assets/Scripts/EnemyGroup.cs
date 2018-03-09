using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour {

    private enum EMovementDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    public float width = 10f;
    public float height = 5f;
    public float speed = 2.5f;

    public float verticalMovement = 1f;


    public GameObject[] enemyPrefabs;
    public float enemySpawnCooldown = 0.25f;


    private EMovementDirection m_moveDir = EMovementDirection.Right;
    private EMovementDirection m_LastDir = EMovementDirection.Left;
    private float m_xMin;
    private float m_xMax;
    private float m_remainingVertDistance;


	// Use this for initialization
	void Start () {
        // Calculate our maximum
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        m_xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x;
        m_xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x;

        SpawnUntilFull();
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
	
	// Update is called once per frame
	void Update () {

        switch (m_moveDir)
        {
            case EMovementDirection.Left:
                transform.position = (Vector2)transform.position + Vector2.left * speed * Time.deltaTime;

                float leftEdgeOfFormation = transform.position.x - (0.5f * width);
                if (leftEdgeOfFormation <= m_xMin)
                {
                    //m_remainingVertDistance = verticalMovement;
                    //m_moveDir = EMovementDirection.Down;
                    //m_LastDir = EMovementDirection.Left;

                    m_moveDir = EMovementDirection.Right;
                }
                break;
            case EMovementDirection.Right:
                transform.position = (Vector2)transform.position + Vector2.right * speed * Time.deltaTime;

                float rightEdgeOfFormation = transform.position.x + (0.5f * width);
                if (rightEdgeOfFormation >= m_xMax)
                {
                    //m_remainingVertDistance = verticalMovement;
                    //m_moveDir = EMovementDirection.Down;
                    //m_LastDir = EMovementDirection.Right;

                    m_moveDir = EMovementDirection.Left;
                }
                break;
            case EMovementDirection.Down:
                if (m_remainingVertDistance > 0)
                {
                    Vector2 nextPosition = (Vector2)transform.position + Vector2.down * speed * Time.deltaTime;
                    m_remainingVertDistance -= transform.position.y - nextPosition.y;
                    transform.position = nextPosition;
                }
                else
                {
                    if (m_LastDir == EMovementDirection.Left)
                    {
                        m_moveDir = EMovementDirection.Right;
                    }
                    else
                    {
                        m_moveDir = EMovementDirection.Left;
                    }
                }
                transform.position = Vector2.down * speed * Time.deltaTime;
                break;
        }

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
    }

    private bool AllMembersDead()
    {
        foreach (Transform childGameObject in transform)
        {
            if (childGameObject.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    Transform NextFreePosition()
    {
        foreach (Transform childGameObject in transform)
        {
            if (childGameObject.childCount == 0)
            {
                return childGameObject;
            }
        }

        return null;
    }

    private void SpawnEnemy(Transform transform)
    {
        int enemyIndex = Random.Range(0, 4);

        GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], transform.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = transform; 
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition != null)
        {
            SpawnEnemy(freePosition);

            if (NextFreePosition() != null)
            {
                Invoke("SpawnUntilFull", enemySpawnCooldown);
            }
        }
    }
}

