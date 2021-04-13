using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer_CS : MonoBehaviour
{
    private Transform playerTransform;
    //[SerializeField] private Transform npcTransform = null;
    [SerializeField] private string playerTag = "Player";
    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private livesSystem_CS livesSystem;
    private int lives;

    // Start is called before the first frame update
    private void Awake() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;
        livesSystem = GameObject.FindWithTag(playerTag).GetComponent<livesSystem_CS>();
    }

    private void Start() 
    {
        lives = livesSystem.GetCurrentLives();
        currentPosition = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //SetNPCPosition();
        NPCMovement();
    }

/*    private void SetNPCPosition() 
    {
        switch (lives) 
        {
            case 3:
                
                break;
            case 2:
                
                break;
            case 1:
                
                break;
            default:
                
                break;
        }        
    }*/

    private void NPCMovement() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;

        targetPosition = playerTransform.position;
        currentPosition = this.transform.position;

        int lives = livesSystem.GetCurrentLives();
        float delta = 0.04f;

        switch (lives) 
        {
            case 3:
                targetPosition.z -= 0.20f;
                break;
            case 2:
                targetPosition.z -= 0.10f;
                break;
            case 1:
                targetPosition.z -= 0f;
                break;
            default:
                targetPosition.z -= 0f;
                break;
        }

        transform.position = Vector3.Lerp(currentPosition, targetPosition, delta);
    }

}
