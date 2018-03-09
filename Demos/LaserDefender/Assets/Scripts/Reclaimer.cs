using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reclaimer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision detected. Triggering self destruct");

        collider.gameObject.GetComponent<SelfDestruct>().Trigger();
    }
}
