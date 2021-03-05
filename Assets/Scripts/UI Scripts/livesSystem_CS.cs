using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesSystem_CS : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;
    private int deathValue = 0;
    private bool playerIsCaught = false;
    
    [SerializeField] private GameObject mainGameplayUIGO = null;
    private mainGameplayUI_CS mainGameplayUI;

    private void Start() 
    {
        mainGameplayUI = mainGameplayUIGO.GetComponent<mainGameplayUI_CS>();
        SetLives();
    }

    private void SetLives() 
    {
        currentLives = maxLives;
        playerIsCaught = false;
        mainGameplayUI.SetBool(playerIsCaught);
    }

    public void subtractLives() 
    {
        currentLives -= 1;
        
        if (currentLives <= deathValue) 
        {
            currentLives = 0;
            playerIsCaught = true;
            mainGameplayUI.SetBool(playerIsCaught);
            //pause game or go to the win/lose screen
        }

        Debug.Log("Current Lives: " + currentLives);
    }

    public bool PlayerCaught() 
    {
        bool condition = playerIsCaught;
        return condition;
    }

    public int GetCurrentLives() 
    {
        int lives = currentLives;
        return lives;
    }
}
