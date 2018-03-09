using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrophy : MonoBehaviour
{
    private void AddStarsToTotal(int count)
    {
        DefenderSpawner.AddStars(count);
    }
}
