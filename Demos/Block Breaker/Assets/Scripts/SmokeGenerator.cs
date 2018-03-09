using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGenerator : MonoBehaviour {

    public GameObject smokePrefab;

    private static SmokeGenerator instance;

    private Queue<GameObject> m_availableSmokeObjects;

    void Awake()
    {
        if (SmokeGenerator.instance == null)
        {
            SmokeGenerator.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameObject TriggerSmoke(GameObject destroyedObject)
    {
        GameObject smoke;

        if (SmokeGenerator.instance.m_availableSmokeObjects == null)
        {
            SmokeGenerator.instance.m_availableSmokeObjects = new Queue<GameObject>();
        }

        if (SmokeGenerator.instance.m_availableSmokeObjects.Count > 0)
        {
            smoke = SmokeGenerator.instance.m_availableSmokeObjects.Dequeue();
            smoke.transform.position = destroyedObject.transform.position;

            ParticleSystem smokeSystem = smoke.GetComponent<ParticleSystem>();

            smokeSystem.startColor = destroyedObject.GetComponent<SpriteRenderer>().color;
            smokeSystem.Play();
        }
        else
        {
            smoke = GameObject.Instantiate(SmokeGenerator.instance.smokePrefab, destroyedObject.transform.position, Quaternion.identity);
            smoke.GetComponent<ParticleSystem>().startColor = destroyedObject.GetComponent<SpriteRenderer>().color;
        }

        return smoke;
    }

    public static void SmokeFinished(GameObject smokeObject)
    {
        if (!SmokeGenerator.instance.m_availableSmokeObjects.Contains(smokeObject))
        {
            SmokeGenerator.instance.m_availableSmokeObjects.Enqueue(smokeObject);
        }
    }

}
