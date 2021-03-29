using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverUI_CS : MonoBehaviour
{
    [SerializeField] private Text encouragementText = null;
    private bool playerCaught;
    private string stageLabel;
    private int passCount, stageNumber, levelNumber;

    [SerializeField] private GameObject winUI = null, loseUI = null, hallPassIcons = null;
    [SerializeField] private GameObject[] hallPasses = null;
    [SerializeField] private Animator playerAnim = null;

    // Start is called before the first frame update
    void Start()
    {
        int value = PlayerPrefs.GetInt("PlayerCaught");

        if (value == 0) playerCaught = false;
        else playerCaught = true;

        if (playerCaught) 
        {
            loseUI.SetActive(true);
            winUI.SetActive(false);
            hallPassIcons.SetActive(false);
            encouragementText.text = "ALMOST THERE! try again?";
            playerAnim.SetBool("Loop", true);
            playerAnim.Play("Base Layer.Player_DejectedAnim");
        }

        else 
        {
            loseUI.SetActive(false);
            winUI.SetActive(true);
            encouragementText.text = "GREAT JOB!";
            playerAnim.SetBool("Loop", true);
            playerAnim.Play("Base Layer.Player_StartWinAnim");

            stageNumber = PlayerPrefs.GetInt("StageNumber");
            levelNumber = PlayerPrefs.GetInt("LevelNumber");
            stageLabel = "Stage" + stageNumber + "Level" + levelNumber + "Passes";
            passCount = PlayerPrefs.GetInt(stageLabel);

            switch (passCount) 
            {
                case 3: 
                    hallPasses[0].SetActive(true);
                    hallPasses[1].SetActive(true);
                    hallPasses[2].SetActive(true);
                    break;
                case 2:
                    hallPasses[0].SetActive(true);
                    hallPasses[1].SetActive(true);
                    hallPasses[2].SetActive(false); 
                    break;
                case 1: 
                    hallPasses[0].SetActive(true);
                    hallPasses[1].SetActive(false);
                    hallPasses[2].SetActive(false);
                    break;
                default:
                    hallPasses[0].SetActive(false);
                    hallPasses[1].SetActive(false);
                    hallPasses[2].SetActive(false);
                    break;
            }
        }
    }

    void FixedUpdate() 
    {
        if (playerCaught) 
        {
            playerAnim.SetBool("Loop", true);
            playerAnim.Play("Base Layer.Player_DejectedAnim");
        }

        else 
        {
            playerAnim.SetBool("Loop", true);
            playerAnim.Play("Base Layer.Player_winAnimationLoop");
        }
    }
}
