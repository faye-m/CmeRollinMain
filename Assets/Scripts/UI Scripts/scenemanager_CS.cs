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
}
