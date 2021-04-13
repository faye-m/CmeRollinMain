using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement_CS : MonoBehaviour
{
    //instantiate variables here
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 objectPosOnScreen;
    private Vector3 direction;

    [SerializeField] private float minX = -10f /*-2.6f*/, maxX = 10f /*2.6f*/;

    [SerializeField] private float slideSpeed = 10f;
    [SerializeField] private float rollingSpeed = 5f;

    private Rigidbody playerRB;
    private Camera gameCamera;

    private Ray detectionRay;
    private Plane detectionPlane;
    private float distance;

    private bool usingKeys = true;
    //private bool isOnEdgeOfMap = false;

    private playerAnimations_CS animations;

    private void Start() 
    {
        playerRB = GetComponent<Rigidbody>();
        animations = GetComponent<playerAnimations_CS>();
        gameCamera = Camera.main;
    }

    private void FixedUpdate() 
    {
        DetectInputModes();
    }

    private void CallAnimations(float targetPosX, float currentPosX) 
    {
         
        if (targetPosX > currentPosX) animations.TurningRight();
        else if (targetPosX < currentPosX) animations.TurningLeft();
        else animations.GoingForward();
    }

    private void DetectInputModes() 
    {
        if (Input.GetButtonDown("Left Click") || Input.GetAxis("Mouse X") !=0) usingKeys = false;

        
        if (Input.GetAxis("Horizontal") != 0) 
        {
            usingKeys = true;
            KeyboardControls();
        }

        else if (Input.mousePresent && !usingKeys) 
        {
            MouseControls();
        }

        else if (Input.touchCount > 0) 
        {
            usingKeys = false;
            MobileControls();
        }

        else 
        {
            playerRB.velocity = Vector3.forward * rollingSpeed; //  * Time.deltaTime;
            animations.GoingForward();
        }
    }

    private void MovePlayer(Vector3 curPos, Vector3 tarPos) 
    {
        //var delta = Time.deltaTime * Vector3.Distance(curPos, tarPos);

        //transform.position = Vector3.MoveTowards(curPos, tarPos, delta);
        //playerRB.velocity = transform.forward * rollingSpeed;

        if (tarPos.x >= maxX) tarPos.x = maxX;
        else if  (tarPos.x <= minX) tarPos.x = minX;

        CallAnimations(tarPos.x, curPos.x);

        direction = ((tarPos - curPos) * slideSpeed + Vector3.forward * rollingSpeed); // * Time.deltaTime;
        playerRB.velocity = direction;
    }

    private void MobileControls() 
    {
        Touch touch = Input.GetTouch(0);
        objectPosOnScreen = touch.position;

        detectionPlane = new Plane(Vector3.up, 0);
        detectionRay = gameCamera.ScreenPointToRay(objectPosOnScreen);

        if (detectionPlane.Raycast(detectionRay, out distance)) targetPosition = detectionRay.GetPoint(distance);

        //Debug.Log("Finger Position: " + targetPosition);

        currentPosition = transform.position;
        targetPosition.z = currentPosition.z;

        MovePlayer(currentPosition, targetPosition);

    }

    private void MouseControls() 
    {
        objectPosOnScreen = Input.mousePosition;
        
        detectionPlane = new Plane(Vector3.up, 0);
        detectionRay = gameCamera.ScreenPointToRay(objectPosOnScreen);

        if (detectionPlane.Raycast(detectionRay, out distance)) targetPosition = detectionRay.GetPoint(distance);

        //Debug.Log("Mouse Position: " + targetPosition);

        currentPosition = transform.position;
        targetPosition.z = currentPosition.z;

        MovePlayer(currentPosition, targetPosition);

    }

    private void KeyboardControls() 
    {
        float sidewardMovement = Input.GetAxis("Horizontal");

        CallAnimations(sidewardMovement, 0f);

        currentPosition = transform.position;

        if ((currentPosition.x >= maxX && sidewardMovement > 0) || (currentPosition.x <= minX && sidewardMovement < 0)) sidewardMovement = 0;

        direction = (Vector3.right * sidewardMovement * slideSpeed + Vector3.forward * rollingSpeed); //* Time.deltaTime;
        playerRB.velocity = direction;

        //if (sidewardMovement > 0 || sidewardMovement < 0) playerRB.velocity = transform.right * sidewardMovement * slideSpeed + transform.forward * rollingSpeed;
        //else playerRB.velocity = Vector3.zero;

        //playerRB.velocity = transform.forward * rollingSpeed;
    }

}
