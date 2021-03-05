using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer_CS : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private string playerTag = "Player";
    private Vector3 currentPosition;
    private Vector3 targetPosition;

    [SerializeField] private GameObject npcGO = null;
    private livesSystem_CS livesSystem;

    // Start is called before the first frame update
    private void Awake() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;
    }

    private void Start() 
    {
        livesSystem = GameObject.FindWithTag(playerTag).GetComponent<livesSystem_CS>();
    }

    // Update is called once per frame
    void Update()
    {
        SetNPCPosition();
        NPCMovement();
    }

    private void NPCMovement() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;

        targetPosition = playerTransform.position;
        currentPosition = this.transform.position;

        var delta = Time.deltaTime * Vector3.Distance(currentPosition, targetPosition);

        transform.position = Vector3.Lerp(currentPosition, targetPosition, delta*4);
    }

    private void SetNPCPosition() 
    {
        int lives = livesSystem.GetCurrentLives();
        Vector3 npcCurrentPos = npcGO.transform.localPosition;
        Vector3 npcTargetPos;
        var delta = Time.deltaTime;

        switch (lives) 
        {
            case 3:
                npcTargetPos = new Vector3( 0f, 0f, -2f);
                delta = Time.deltaTime * Vector3.Distance(npcCurrentPos, npcTargetPos);
                npcGO.transform.localPosition = Vector3.Lerp(npcCurrentPos, npcTargetPos, delta*4);
                break;
            case 2:
                npcTargetPos = new Vector3( 0f, 0f, -1.25f);
                delta = Time.deltaTime * Vector3.Distance(npcCurrentPos, npcTargetPos);
                npcGO.transform.localPosition = Vector3.Lerp(npcCurrentPos, npcTargetPos, delta*4);
                break;
            case 1:
                npcTargetPos = new Vector3( 0f, 0f, -0.5f);
                delta = Time.deltaTime * Vector3.Distance(npcCurrentPos, npcTargetPos);
                npcGO.transform.localPosition = Vector3.Lerp(npcCurrentPos, npcTargetPos, delta*4);
                break;
            default:
                npcTargetPos = new Vector3( 0f, 0f, 0f);
                delta = Time.deltaTime * Vector3.Distance(npcCurrentPos, npcTargetPos);
                npcGO.transform.localPosition = Vector3.Lerp(npcCurrentPos, npcTargetPos, delta*4);
                break;
        }
    }
}
