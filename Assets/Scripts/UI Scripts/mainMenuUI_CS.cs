using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuUI_CS : MonoBehaviour
{
    private bool isOnLevelSelect = false;
    [SerializeField] private GameObject mainMenuUI = null, schoolLevelUI = null, officeLevelUI = null, schoolBackButton = null, officeBackButton = null;
    private int condition;
    
    private void Start() 
    {
        Time.timeScale = 1;
        int condition = PlayerPrefs.GetInt("LevelSelect");

        if (condition == 1) isOnLevelSelect = true;
        else isOnLevelSelect = false; 

        if (isOnLevelSelect) 
        {
            PlayerPrefs.SetInt("LevelSelect", 0);
            mainMenuUI.SetActive(false);

            int stageNumber = PlayerPrefs.GetInt("StageNumber");

            if (stageNumber == 1) 
            {
                schoolLevelUI.SetActive(true);
                schoolBackButton.SetActive(true);
            }
            else if (stageNumber == 2) 
            {
                officeLevelUI.SetActive(true);
                officeBackButton.SetActive(true);
            }
        }
    }

    
}
