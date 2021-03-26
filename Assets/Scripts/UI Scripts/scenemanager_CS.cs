using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenemanager_CS : MonoBehaviour
{
    private string levelName;
    [SerializeField] private int stageNumber = 0; 
    [SerializeField] private int levelNumber = 0;
    private int levelCount = 12;
    private string mainMenuSceneName = "MainMenu";

    private bool gameIsOver = false;
    private bool playerWasCaught = false;

    private void Update() 
    {
        if (gameIsOver) GoToGameOver(playerWasCaught);
    }

    public void LoadLevel() 
    {
        PlayerPrefs.SetInt("StageNumber", stageNumber);
        PlayerPrefs.SetInt("LevelNumber", levelNumber);
        
        PlayerPrefs.SetInt("PlayerCaught", 0);

        levelName = "stage" + stageNumber.ToString() + "_level" + levelNumber.ToString();

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);    
    }

    public void ReloadScene() 
    {
        stageNumber = PlayerPrefs.GetInt("StageNumber");
        levelNumber = PlayerPrefs.GetInt("LevelNumber");

        PlayerPrefs.SetInt("PlayerCaught", 0);

        levelName = "stage" + stageNumber.ToString() + "_level" + levelNumber.ToString();
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    public void GotoMainMenu()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("LevelSelect", 0);
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }

    public void GotoLevelSelect() 
    {
        Time.timeScale = 1;

        PlayerPrefs.SetInt("PlayerCaught", 0);
        PlayerPrefs.SetInt("LevelSelect", 1);
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }

    public int GetStageNumber() 
    {
        return stageNumber;
    }

    public int GetLevelNumber() 
    {
        return levelNumber;
    }

    public void GoToNextLevel() 
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("PlayerCaught", 0);
        
        levelNumber = PlayerPrefs.GetInt("LevelNumber"); 
        stageNumber = PlayerPrefs.GetInt("StageNumber");

        if (levelCount != levelNumber) 
        {
            levelName = "stage" + stageNumber.ToString() + "_level" + (levelNumber + 1).ToString();

            PlayerPrefs.SetInt("StageNumber", stageNumber);
            PlayerPrefs.SetInt("LevelNumber", (levelNumber + 1));
        }
        else 
        {
            levelName = "stage" + (stageNumber + 1).ToString() + "_level" + (1).ToString();

            PlayerPrefs.SetInt("StageNumber", (stageNumber + 1));
            PlayerPrefs.SetInt("LevelNumber", 1);
        }

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    public void GoToPauseScene() 
    {
        levelName = "stage" + stageNumber.ToString() + "_level" + levelNumber.ToString();
        Time.timeScale = 1;

        PlayerPrefs.SetInt("PlayerCaught", 0);
        PlayerPrefs.SetString("LevelToLoad", levelName);
        SceneManager.LoadScene("PauseMenu");
    }

    public void ResumeStage() 
    {
        Time.timeScale = 1;
        levelName = PlayerPrefs.GetString("LevelToLoad");
        SceneManager.LoadScene(levelName);
    }

    public void GameIsOver(bool playerCaught, bool gameOver) 
    {
        gameIsOver = gameOver;
        playerWasCaught = playerCaught;
    }

    public void GoToGameOver(bool playerCaught) 
    {
        PlayerPrefs.SetInt("StageNumber", stageNumber);
        PlayerPrefs.SetInt("LevelNumber", levelNumber);

        if (playerCaught) 
        {
            PlayerPrefs.SetInt("PlayerCaught", 1);
        }

        else 
        {
            PlayerPrefs.SetInt("PlayerCaught", 0);
        }

        SceneManager.LoadScene("GameOverMenu");
        Debug.Log("Load the Game Over Menu");
    }
}
