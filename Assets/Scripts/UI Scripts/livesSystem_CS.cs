using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesSystem_CS : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;
    private int deathValue = 0;
    private bool playerIsCaught = false;

    private void Start() 
    {
        SetLives();
    }

    // Update is called once per frame
    void Update()
    {
        detectConditionsForGameOver();
    }

    private void SetLives() 
    {
        currentLives = maxLives;
        playerIsCaught = false;
    }

    public void subtractLives() 
    {
        currentLives --;
        Debug.Log("Current Lives: " + currentLives);
    }

    private void detectConditionsForGameOver() 
    {
        if (currentLives <= deathValue) 
        {
            currentLives = 0;
            playerIsCaught = true;
            //pause game or go to the win/lose screen
        }
    }

    public bool PlayerCaught() 
    {
        bool condition = playerIsCaught;
        return condition;
    }
}
