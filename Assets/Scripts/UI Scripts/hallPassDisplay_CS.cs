using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallPassDisplay_CS : MonoBehaviour
{
    private int stageNumber, levelNumber;
    private string recordedLabel;
    private int recordedPassCount;

    [SerializeField] private scenemanager_CS sceneManager = null;
    [SerializeField] private GameObject[] hallPassImages = null; 

    private void Awake() 
    {
        stageNumber = sceneManager.GetStageNumber();
        levelNumber = sceneManager.GetLevelNumber();
        recordedLabel = "Stage" + stageNumber + "Level" + levelNumber + "PassesRecord";
        recordedPassCount = PlayerPrefs.GetInt(recordedLabel);
    }

    private void Start() 
    {
        switch (recordedPassCount) 
        {
            case 3:
                hallPassImages[0].SetActive(true);
                hallPassImages[1].SetActive(true);
                hallPassImages[2].SetActive(true);
                break;
            case 2:
                hallPassImages[0].SetActive(true);
                hallPassImages[1].SetActive(true);
                hallPassImages[2].SetActive(false);
                break;
            case 1:
                hallPassImages[0].SetActive(true);
                hallPassImages[1].SetActive(false);
                hallPassImages[2].SetActive(false);
                break;
            default:
                hallPassImages[0].SetActive(false);
                hallPassImages[1].SetActive(false);
                hallPassImages[2].SetActive(false);
                break;
        }
    }
}
