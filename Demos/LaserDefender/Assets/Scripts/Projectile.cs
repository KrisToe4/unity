using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage = 1;

    void Start()
    {
        SelfDestruct sd = GetComponent<SelfDestruct>();
        if (sd == null)
        {
            gameObject.AddComponent<SelfDestruct>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Projectile Hit!");

        // If we hit an enemy or player
        Destructible destructibleObject = collider.gameObject.GetComponent<Destructible>();
        if (destructibleObject != null)
        {
            destructibleObject.Hit(damage);
        }

        // Always
        GetComponent<SelfDestruct>().Trigger();
    }
}
