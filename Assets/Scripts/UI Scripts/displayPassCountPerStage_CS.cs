using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayPassCountPerStage_CS : MonoBehaviour
{
    private scenemanager_CS sceneManager;
    private int stageNumber, levelNumber;
    private string label;
    private int passCount;

    private void Awake() 
    {
        sceneManager = GetComponent<scenemanager_CS>();
        stageNumber = sceneManager.GetStageNumber();
        levelNumber = sceneManager.GetLevelNumber();
        label = "Stage" + stageNumber + "Level" + levelNumber + "Passes";
        passCount = PlayerPrefs.GetInt(label);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
