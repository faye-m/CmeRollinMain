﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGameplayUI_CS : MonoBehaviour
{
    //[SerializeField] private GameObject inGameUISet = null, progressTracker = null;//, pauseMenuUISet = null;
    [SerializeField] private string playerTag = "Player";

    private livesSystem_CS livesSystem;
    private hallPassSystem_CS hallPassSystem;
    private bool levelIsOver = false;
    private bool gameIsPaused = false;

    private analyticsTracker_CS analyticsTracker;
    [SerializeField]private scenemanager_CS sceneManager = null;
    private int stageNumber, levelNumber;

    [SerializeField] private Transform playerTransform = null, goalTransform = null;
    [SerializeField] private Slider progressSlider = null;
    private float distance, totalDist;

    private int passCount = 0, lifeCount;
    [SerializeField] private GameObject[] hallPassImages = null, lifeImages = null;

    private bool gameBegins = true;


    private void Awake() 
    {
        livesSystem = GameObject.FindWithTag(playerTag).GetComponent<livesSystem_CS>();
        hallPassSystem = GameObject.FindWithTag(playerTag).GetComponent<hallPassSystem_CS>();
        analyticsTracker = GameObject.FindWithTag(playerTag).GetComponent<analyticsTracker_CS>();
        totalDist = Vector3.Distance(playerTransform.position, goalTransform.position);

        stageNumber = sceneManager.GetStageNumber();
        levelNumber = sceneManager.GetLevelNumber();
    }

    private void Start() 
    {
        Time.timeScale = 0;
        gameBegins = true;
    }

    private void FixedUpdate() 
    {
        DetectDistacetoGoal();
        GetPassCount();
        GetLifeCount();
        DetectLevelOver();
        DisplayLifeCount();
    }

    private void LateUpdate() 
    {   
        PauseGame();     
        DisplayDistancetoGoal();
        DisplayPassCount();
    }

    public void SetBool(bool condition) 
    {
        levelIsOver = condition;
    }

    private void GetLifeCount() 
    {
        lifeCount = livesSystem.GetCurrentLives();
    }

    private void DisplayLifeCount() 
    {
        if (gameBegins) 
        {
            for (int i = lifeImages.Length - 1; i >= 0; i --) 
            {
                if (!lifeImages[i].activeSelf) lifeImages[i].SetActive(true);
            }
        }

        else 
        {
            switch (lifeCount) 
            {
                case 2:
                    if (lifeImages[2].activeSelf) lifeImages[2].SetActive(false);
                    break;
                case 1:
                    if (lifeImages[1].activeSelf) lifeImages[1].SetActive(false);
                    break;
                case 0:
                    if (lifeImages[0].activeSelf) lifeImages[0].SetActive(false);
                    break;
                default:
                    break;
            }
            
            /*if (lifeCount == 2 && lifeImages[2].activeSelf) lifeImages[2].SetActive(false);
            else if (lifeCount == 1 && lifeImages[1].activeSelf) lifeImages[1].SetActive(false);
            else if (lifeCount == 0 && lifeImages[0].activeSelf) lifeImages[0].SetActive(false);*/
        }

        Debug.Log("Lives: " + lifeCount);
    }

    private void GetPassCount() 
    {
        passCount = hallPassSystem.GetCurrentHallPassCount();
    }

    private void DisplayPassCount() 
    {
        if (passCount == 1 && !hallPassImages[0].activeSelf) hallPassImages[0].SetActive(true);
        if (passCount == 2 && !hallPassImages[1].activeSelf) hallPassImages[1].SetActive(true);
        if (passCount == 3 && !hallPassImages[2].activeSelf) hallPassImages[2].SetActive(true);
    }

    private void DetectDistacetoGoal() 
    {
        distance = Vector3.Distance(playerTransform.position, goalTransform.position);
    }

    private void DisplayDistancetoGoal() 
    {
        progressSlider.value = (totalDist - distance) / totalDist;
    }

    private void DetectLevelOver() 
    {
        if (levelIsOver && livesSystem.PlayerCaught())
        {
            analyticsTracker.OnGameOver(stageNumber, levelNumber, distance, passCount);
            sceneManager.GameIsOver(true, true);
        }

        else if (levelIsOver && !livesSystem.PlayerCaught()) 
        {
            analyticsTracker.OnGameClear(stageNumber, levelNumber, passCount);

            string label = "Stage" + stageNumber + "Level" + levelNumber + "Passes";
            string recordedLabel = "Stage" + stageNumber + "Level" + levelNumber + "PassesRecord";
            int recordedCount = PlayerPrefs.GetInt(recordedLabel);
            if (passCount > recordedCount) 
            {
                //record the pass count for this particular level
                PlayerPrefs.SetInt(recordedLabel, passCount);

                //set the total amount of unlocked passes for this stage
                string stageTotalLabel = "Stage" + stageNumber + "TotalPassCount";
                int totalStagePassCount = PlayerPrefs.GetInt(stageTotalLabel);
                totalStagePassCount += (passCount - recordedCount);
                PlayerPrefs.SetInt(stageTotalLabel, totalStagePassCount);
            }
            PlayerPrefs.SetInt(label, passCount);
            
            string unlockLabel; 
            if (levelNumber < 10) unlockLabel = "Stage" + stageNumber.ToString() + "Level" + (levelNumber+1).ToString() + "Unlocked";
            else unlockLabel = "Stage" + (stageNumber+1).ToString() + "Level" + (1).ToString() + "Unlocked";
            PlayerPrefs.SetInt (unlockLabel, 1);

            sceneManager.GameIsOver(false, true);
        }

        /*if (levelIsOver && livesSystem.PlayerCaught() && !screenDisplayed) 
        {
            analyticsTracker.OnGameOver(stageNumber, levelNumber, distance, passCount);

            gameOverUISet.SetActive(true);
            loseUISet.SetActive(true);
            winUISet.SetActive(false);
            inGameUISet.SetActive(false);
            progressTracker.SetActive(false);
            screenDisplayed = true;
            
        }

        else if (levelIsOver && !livesSystem.PlayerCaught() && !screenDisplayed) 
        {
            analyticsTracker.OnGameClear(stageNumber, levelNumber, passCount);

            gameOverUISet.SetActive(true);
            loseUISet.SetActive(false);
            winUISet.SetActive(true);
            inGameUISet.SetActive(false);
            progressTracker.SetActive(false);
            screenDisplayed = true;

            string label = "Stage" + stageNumber + "Level" + levelNumber + "Passes";
            int recordedCount = PlayerPrefs.GetInt(label);
            if (passCount > recordedCount) PlayerPrefs.SetInt(label, passCount);
        }

        else if (!levelIsOver && screenDisplayed) 
        {
            gameOverUISet.SetActive(false);
            loseUISet.SetActive(false);
            winUISet.SetActive(false);
            progressTracker.SetActive(true);
            screenDisplayed = false;
        }*/

        /*if (levelIsOver) Time.timeScale = 0;
        else */if (!levelIsOver && !gameIsPaused && !gameBegins) Time.timeScale = 1;
    }

    public void PauseButton() 
    {
        if (!levelIsOver && !gameIsPaused) gameIsPaused = true;
        else if (!levelIsOver && gameIsPaused) gameIsPaused = false;
    }

    private void PauseGame() 
    {
        if (gameIsPaused && !gameBegins) 
        {
            Time.timeScale = 0;
        }
        else if (!gameIsPaused && !gameBegins)
        {
            Time.timeScale = 1;
        }
    }

    public void ResumeButton() 
    {
        gameIsPaused = false;
    }

    public void BeginTheGame() 
    {
        gameBegins = false;
    }
}
