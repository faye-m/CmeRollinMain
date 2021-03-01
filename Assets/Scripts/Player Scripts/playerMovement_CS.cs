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

    [SerializeField] private float slideSpeed = 10f;
    [SerializeField] private float rollingSpeed = 5f;

    private Rigidbody playerRB;
    private Camera gameCamera;

    private Ray detectionRay;
    private Plane detectionPlane;
    private float distance;

    private bool usingKeys = true;

    private void Start() 
    {
        playerRB = GetComponent<Rigidbody>();
        gameCamera = Camera.main;
    }

    private void Update() 
    {
        DetectInputModes();
    }

    private void DetectInputModes() 
    {
        if (Input.GetAxis("Mouse X") !=0 || Input.GetAxis("Mouse Y") != 0) usingKeys = false;

        if (Input.GetAxis("Horizontal") != 0) 
        {
            usingKeys = true;
            KeyboardControls();
        }

        else if (Input.touchCount > 0) 
        {
            usingKeys = false;
            MobileControls();
        }

        else if (Input.mousePresent && !usingKeys) 
        {
            MouseControls();
        }

        else playerRB.velocity = transform.forward * rollingSpeed;
    }

    private void MovePlayer(Vector3 curPos, Vector3 tarPos) 
    {
        var delta = Time.deltaTime * Vector3.Distance(curPos, tarPos);

        transform.position = Vector3.MoveTowards(curPos, tarPos, delta);
        playerRB.velocity = transform.forward * rollingSpeed;
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
        if (sidewardMovement > 0 || sidewardMovement < 0) playerRB.velocity = transform.right * sidewardMovement * slideSpeed + transform.forward * rollingSpeed;
        else playerRB.velocity = Vector3.zero;

        //playerRB.velocity = transform.forward * rollingSpeed;
    }
}
