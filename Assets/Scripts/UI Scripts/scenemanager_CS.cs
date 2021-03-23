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

    public void LoadLevel() 
    {
        levelName = "stage" + stageNumber.ToString() + "_level" + levelNumber.ToString();

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);    
    }

    public void ReloadScene() 
    {
        Scene activeLevel = SceneManager.GetActiveScene();
        levelName = activeLevel.name;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    public void GotoMainMenu()
    {
        PlayerPrefs.SetInt("LevelSelect", 0);
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }

    public void GotoLevelSelect() 
    {
        PlayerPrefs.SetInt("LevelSelect", 1);
        PlayerPrefs.SetInt("StageNumber", stageNumber);
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
        if (levelCount != levelNumber) levelName = "stage" + stageNumber.ToString() + "_level" + (levelNumber + 1).ToString();
        else levelName = "stage" + (stageNumber + 1).ToString() + "_level" + (1).ToString();

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
