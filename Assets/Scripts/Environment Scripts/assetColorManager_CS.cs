using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetColorManager_CS : MonoBehaviour
{
    [SerializeField] private Material assetMat = null;
    private scenemanager_CS sceneManager;
    private int stageNumber, levelNumber;
    private Color assetColor;
    [SerializeField] Color[] colorOptions = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        sceneManager = GetComponent<scenemanager_CS>();
        stageNumber = sceneManager.GetStageNumber();
        levelNumber = sceneManager.GetLevelNumber();

        if (stageNumber == 2) 
        {
            switch (levelNumber) 
            {
                case 10:
                    assetColor = colorOptions[4];
                    break;
                case 9:
                    assetColor = colorOptions[3];
                    break;
                case 8:
                    assetColor = colorOptions[2];
                    break;
                case 7:
                    assetColor = colorOptions[1];
                    break;
                case 6:
                    assetColor = colorOptions[0];
                    break;
                case 5:
                    assetColor = colorOptions[4];
                    break;
                case 4:
                    assetColor = colorOptions[3];
                    break;
                case 3:
                    assetColor = colorOptions[2];
                    break;
                case 2:
                    assetColor = colorOptions[1];
                    break;
                default:
                    assetColor = colorOptions[0];
                    break;
            }

            assetMat.SetColor("_Tint", assetColor);
        }
    }

}
