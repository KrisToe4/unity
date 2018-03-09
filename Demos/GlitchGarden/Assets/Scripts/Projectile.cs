using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 5f;
    public int damage = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;

        if (otherObject.GetComponent<Attacker>() != null)
        {
            AgentHealth healthScript = otherObject.GetComponent<AgentHealth>();
            healthScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
