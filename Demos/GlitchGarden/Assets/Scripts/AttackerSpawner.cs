using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackerPrefabs)
        {
            if (CheckAttackerSpawn(attacker))
            {
                GameObject newAttacker = Instantiate(attacker, gameObject.transform.position, Quaternion.identity);
                newAttacker.transform.parent = gameObject.transform;
            }
        }
	}

    private bool CheckAttackerSpawn(GameObject attackerPrefab)
    {
        Attacker attackerScript = attackerPrefab.GetComponent<Attacker>();

        float meanSpawnDelay = attackerScript.spawnFrequency;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped at framerate");
        }

        float threshold = (spawnsPerSecond * Time.deltaTime) / 5;
        if (Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
