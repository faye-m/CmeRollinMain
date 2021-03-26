using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuUI_CS : MonoBehaviour
{
    private bool isOnLevelSelect = false;
    [SerializeField] private GameObject mainMenuUI = null, schoolLevelUI = null, officeLevelUI = null;

    [SerializeField] private int unlockStage2PassCount = 15;
    private int stage1PassCount;
    private int stage2PassCount;

    private void Start() 
    {
        Time.timeScale = 1;
        int condition = PlayerPrefs.GetInt("LevelSelect");

        if (condition == 1) isOnLevelSelect = true;
        else if (condition == 0) isOnLevelSelect = false; 

        if (isOnLevelSelect) 
        {
            mainMenuUI.SetActive(false);

            int stageNumber = PlayerPrefs.GetInt("StageNumber");

            if (stageNumber == 1) schoolLevelUI.SetActive(true);
            else if (stageNumber == 2) officeLevelUI.SetActive(true);
        }
    }

    
}
