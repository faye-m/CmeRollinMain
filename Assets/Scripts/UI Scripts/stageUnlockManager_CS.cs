using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageUnlockManager_CS : MonoBehaviour
{
    [SerializeField] private int stage1MinUnlockValue = 15;
    [SerializeField] private Button stage2LvlSelectButton = null;
    private int stage1TotalPassCount;
    [SerializeField] private Image buttonImage = null;

    private void Awake() 
    {
        stage1TotalPassCount = PlayerPrefs.GetInt("Stage1TotalPassCount");
        Debug.Log("Collected Stage 1 Passes: " + stage1TotalPassCount);
        if (stage2LvlSelectButton != null) 
        {
            if (stage1TotalPassCount >= stage1MinUnlockValue && stage2LvlSelectButton.interactable == false) 
            {
                stage2LvlSelectButton.interactable = true;
                buttonImage.color = Color.white;
            }

            else 
            {
                stage2LvlSelectButton.interactable = false;
                buttonImage.color = Color.grey;
            }
        }
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
