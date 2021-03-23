using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class analyticsTracker_CS : MonoBehaviour
{

    // gives data related to when the player loses the level
    public void OnGameOver(int stage, int level, float distanceToGoal, int hallPassCollected) 
    {
        Analytics.CustomEvent("Game Over", new Dictionary<string, object>
        {
            {"Stage", stage},
            {"Level", level},
            {"Progress to Finish Line", distanceToGoal},
            {"HallPass Collected", hallPassCollected}
        });
    }
    
    //gives data on the level the player has cleared and how many passes they cleared it with
    public void OnGameClear(int stage, int level, int hallPassCollected) 
    {
        Analytics.CustomEvent("Stage Cleared", new Dictionary<string, object>
        {
            {"Stage", stage},
            {"Level", level},
            {"HallPass Collected", hallPassCollected}
        });
    }

    // gives data on the obstacle that players hit the most in a specific level
    public void OnPlayerHitsObstacle(string assetName, int stage, int level, Vector3 position) 
    {
        Analytics.CustomEvent("Obstacles Hit", new Dictionary<string, object>
        {
            {"Stage", stage},
            {"Level", level},
            {"Asset Name", assetName},
            {"Position on Scene", position}
        });
    }
}
