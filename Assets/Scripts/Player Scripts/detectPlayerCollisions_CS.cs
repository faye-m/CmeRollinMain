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
    private analyticsTracker_CS analyticsTracker;
    [SerializeField] private mainGameplayUI_CS mainGameplayUI = null;
    [SerializeField] private scenemanager_CS sceneManager = null;
    private playerAnimations_CS animations;
    private fadeOut_CS fade;

    private void Awake() 
    {
        livesSystem = GetComponent<livesSystem_CS>();
        hallPassSystem = GetComponent<hallPassSystem_CS>();
        playerMovement = GetComponent<playerMovement_CS>();
        analyticsTracker = GetComponent<analyticsTracker_CS>();
        animations = GetComponent<playerAnimations_CS>();
    }

    private void OnTriggerEnter (Collider other) 
    {
        if (other.tag == obstacleTag) 
        {
            //run related script to handle player lives
            livesSystem.subtractLives();
            
            //script accesses the object and runs the script associated with despawning it
            Destroy(other.gameObject);
            
            //analytics
            int stageNumber = sceneManager.GetStageNumber();
            int levelNumber = sceneManager.GetLevelNumber();
            Vector3 playerPosition =  this.transform.position;
            analyticsTracker.OnPlayerHitsObstacle(other.name, stageNumber, levelNumber, playerPosition);

            //play animations involved
            animations.PlayerGetsHit();
        }

        if (other.tag == passTag) 
        {
            //run related script to handle hall passes obtained
            hallPassSystem.AddHallPass();

            //script accesses the object and runs the script associated with despawning it
            fade = other.gameObject.GetComponent<fadeOut_CS>();
            fade.SetBool(true);

            other.enabled = false;

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
