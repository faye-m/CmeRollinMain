using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGameplayUI_CS : MonoBehaviour
{
    private GameObject gameOverCanvas, winUISet, loseUISet;
    [SerializeField] private string goCanvasTag = "levelIsOver";
    [SerializeField] private string winTag = "playerWin";
    [SerializeField] private string loseTag = "playerLose";
    [SerializeField] private string playerTag = "Player";

    private livesSystem_CS livesSystem;
    private bool levelIsOver = false;

    private void Start() 
    {
        gameOverCanvas = GameObject.FindWithTag(goCanvasTag);
        winUISet = GameObject.FindWithTag(winTag);
        loseUISet = GameObject.FindWithTag(loseTag);
        livesSystem = GameObject.FindWithTag(playerTag).GetComponent<livesSystem_CS>();
    }

    private void FixedUpdate() 
    {

    }

    public void SetBool(bool condition) 
    {
        levelIsOver = condition;
    }

    private void DetectLevelOver() 
    {
        if (levelIsOver && livesSystem.PlayerCaught()) 
        {

        }

        else if (levelIsOver && !livesSystem.PlayerCaught()) 
        {

        }

        else if (!levelIsOver) 
        {

        }
    }
}
