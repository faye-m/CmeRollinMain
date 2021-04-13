using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelLocked_CS : MonoBehaviour
{
    [SerializeField] private scenemanager_CS sceneManager = null;
    private int stageNumber, levelNumber;
    [SerializeField] private Image padlock = null, buttonImage = null;
    [SerializeField] private Button levelButton = null;
    // Start is called before the first frame update
    void Start()
    {
        stageNumber = sceneManager.GetStageNumber();
        levelNumber = sceneManager.GetLevelNumber();

        string label = "Stage" + stageNumber.ToString() + "Level" + levelNumber.ToString() + "Unlocked";
        int unlockCondition = PlayerPrefs.GetInt(label);

        if (levelNumber == 1) unlockCondition = 1;
        
        if (unlockCondition != 0) 
        {
            levelButton.interactable = true;
            buttonImage.color = Color.white;
            padlock.enabled = false;
        }

        else 
        {
            levelButton.interactable = false;
            buttonImage.color = Color.gray;
            padlock.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
