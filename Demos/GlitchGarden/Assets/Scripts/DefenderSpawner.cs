using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public static int CurrentStarCount = 10;
    public static void AddStars(int count)
    {
        DefenderSpawner.CurrentStarCount += count;
    }

    private Transform m_defenderContainer;

	// Use this for initialization
	void Start () {
        GameObject defenders = GameObject.Find("Defenders");
        if (defenders == null)
        {
            defenders = new GameObject("Defenders");
        }
        m_defenderContainer = defenders.transform;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        DefenderButton defenderToSpawn = DefenderButton.selectedDefender.GetComponent<DefenderButton>();
        if (defenderToSpawn != null) 
        {
            Vector2 gridCoord = SnapToGrid(ConvertMouseCoordToWorldView());

            GameObject newDefender = Instantiate(defenderToSpawn.DefenderPrefab, gridCoord, Quaternion.identity);
            newDefender.transform.parent = m_defenderContainer;

            CurrentStarCount -= defenderToSpawn.StarCost;
        }
    }

    private Vector2 ConvertMouseCoordToWorldView()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceToCamera = 10f;

        Vector3 conversionVector = new Vector3(mouseX, mouseY, distanceToCamera);
        return Camera.main.ScreenToWorldPoint(conversionVector);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        return new Vector2(Mathf.Round(rawWorldPos.x), Mathf.Round(rawWorldPos.y));
    }
}
