using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer_CS : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private string playerTag = "Player";
    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private livesSystem_CS livesSystem;

    // Start is called before the first frame update
    private void Awake() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;
        livesSystem = GameObject.FindWithTag(playerTag).GetComponent<livesSystem_CS>();
    }

    private void Start() 
    {
    }

    // Update is called once per frame
    void Update()
    {
        //SetNPCPosition();
        NPCMovement();
    }

    private void NPCMovement() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;

        targetPosition = playerTransform.position;
        currentPosition = this.transform.position;

        int lives = livesSystem.GetCurrentLives();
        float delta;

        switch (lives) 
        {
            case 3:
                delta = 0.025f;
                break;
            case 2:
                delta = 0.030f;
                break;
            case 1:
                delta = 0.035f;
                break;
            default:
                delta = 0.04f;
                break;
        }

        transform.position = Vector3.Lerp(currentPosition, targetPosition, delta);
    }

}
