using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour {

    public float projectileSpeed = 5f;
    public float rechargeRate = 1f;
    public float projectileOffset = 1f;

    public GameObject projectilePrefab;
    public AudioClip fireSound;

    private float m_currRecharge = 0f;

    public float CurrentRecharge
    {
        get
        {
            return m_currRecharge;
        }
    }

    // Use this for initialization
    void Start () {
	}

    void Update()
    {
        m_currRecharge -= Time.deltaTime;
    }

    public void FireLaser()
    {
        GameObject laser = Instantiate(projectilePrefab, new Vector2(transform.position.x, transform.position.y + projectileOffset), Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * projectileSpeed;
        AudioSource.PlayClipAtPoint(fireSound, transform.position);

        m_currRecharge = rechargeRate;
    }
}
