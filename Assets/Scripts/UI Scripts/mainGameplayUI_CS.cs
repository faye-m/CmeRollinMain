using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGameplayUI_CS : MonoBehaviour
{
    [SerializeField] private GameObject inGameUISet = null, gameOverUISet = null, winUISet = null, loseUISet = null, pauseMenuUISet = null;
    [SerializeField] private string playerTag = "Player";

    private livesSystem_CS livesSystem;
    private bool levelIsOver = false;
    private bool gameIsPaused = false;


    private void Start() 
    {
        livesSystem = GameObject.FindWithTag(playerTag).GetComponent<livesSystem_CS>();
    }

    private void FixedUpdate() 
    {

    }

    private void LateUpdate() 
    {
        PauseGame();
        DetectLevelOver();
    }

    public void SetBool(bool condition) 
    {
        levelIsOver = condition;
    }

    private void DetectLevelOver() 
    {
        if (levelIsOver && livesSystem.PlayerCaught()) 
        {
            //Sets the 
            gameOverUISet.SetActive(true);
            loseUISet.SetActive(true);
            winUISet.SetActive(false);
            inGameUISet.SetActive(false);
            Time.timeScale = 0;
        }

        else if (levelIsOver && !livesSystem.PlayerCaught()) 
        {
            gameOverUISet.SetActive(true);
            loseUISet.SetActive(false);
            winUISet.SetActive(true);
            inGameUISet.SetActive(false);
            Time.timeScale = 0;
        }

        else if (!levelIsOver) 
        {
            gameOverUISet.SetActive(false);
            loseUISet.SetActive(false);
            winUISet.SetActive(false);
            if (!gameIsPaused) Time.timeScale = 1;
        }
    }

    public void PauseButton() 
    {
        if (!levelIsOver && !gameIsPaused) gameIsPaused = true;
        else if (!levelIsOver && gameIsPaused) gameIsPaused = false;
    }

    private void PauseGame() 
    {
        if (gameIsPaused) 
        {
            inGameUISet.SetActive(false);
            pauseMenuUISet.SetActive(true);
            Time.timeScale = 0;
        }
        else 
        {
            inGameUISet.SetActive(true);
            pauseMenuUISet.SetActive(false);
        }
    }

    public void ResumeButton() 
    {
        gameIsPaused = false;
    }
}
