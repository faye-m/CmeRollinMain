using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesSystem_CS : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;
    private int deathValue = 0;
    private bool playerIsCaught = false;
    
    [SerializeField] private string gameUITag = "normalModeUI";
    private mainGameplayUI_CS mainGameplayUI;

    private void Start() 
    {
        SetLives();
        mainGameplayUI = GameObject.FindWithTag(gameUITag).GetComponent<mainGameplayUI_CS>();
    }

    private void SetLives() 
    {
        currentLives = maxLives;
        playerIsCaught = false;
        mainGameplayUI.SetBool(playerIsCaught);
    }

    public void subtractLives() 
    {
        currentLives --;
        
        if (currentLives <= deathValue) 
        {
            currentLives = 0;
            playerIsCaught = true;
            //pause game or go to the win/lose screen
            mainGameplayUI.SetBool(playerIsCaught);
        }

        Debug.Log("Current Lives: " + currentLives);
    }

    public bool PlayerCaught() 
    {
        bool condition = playerIsCaught;
        return condition;
    }
}
