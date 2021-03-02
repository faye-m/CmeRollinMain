using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenemanager_CS : MonoBehaviour
{
    private string levelName;

    public void LoadLevel(int stageNumber, int levelNumber) 
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
}
