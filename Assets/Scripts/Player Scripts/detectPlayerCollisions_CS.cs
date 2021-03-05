using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayerCollisions_CS : MonoBehaviour
{
    //declare variables
    [SerializeField] private string obstacleTag = "obstacle";
    [SerializeField] private string passTag = "hallPass";
    [SerializeField] private string finishLineTag = "goal";
    [SerializeField] private string customItemTag = "customItem";

    private livesSystem_CS livesSystem;
    private hallPassSystem_CS hallPassSystem;
    private playerMovement_CS playerMovement;
    [SerializeField] private mainGameplayUI_CS mainGameplayUI = null;

    private void Awake() 
    {
        livesSystem = GetComponent<livesSystem_CS>();
        hallPassSystem = GetComponent<hallPassSystem_CS>();
        playerMovement = GetComponent<playerMovement_CS>();
    }

    private void OnTriggerEnter (Collider other) 
    {
        if (other.tag == obstacleTag) 
        {
            Debug.Log("Player loses one life or enters Game Over when the lives reach 0");
            
            //run related script to handle player lives
            livesSystem.subtractLives();

            //play animations involved
        }

        if (other.tag == passTag) 
        {
            Debug.Log("Player obtains a hall pass");

            //run related script to handle hall passes obtained
            hallPassSystem.AddHallPass();
            Destroy(other.gameObject);

            //call related UI and Particle Animations here
        }

        if (other.tag == finishLineTag) 
        {
            Debug.Log("Player wins the level, CONGRATS!");

            //tells the game that the level is finished
            mainGameplayUI.SetBool(true);
            
            //play animations involved
        }

        if (other.tag == customItemTag) 
        {
            // call related UI and Particle Animations here
            Debug.Log("You've obtained a HAT! Got to the customize menu to see how it looks on you.");
            Destroy(other.gameObject);
        }
    }
}
