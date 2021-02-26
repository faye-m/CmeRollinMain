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
    }

    private void MobileControls() 
    {

    }

    private void MouseControls() 
    {
        objectPosOnScreen = Input.mousePosition;
        
        detectionPlane = new Plane(Vector3.up, 0);
        detectionRay = gameCamera.ScreenPointToRay(objectPosOnScreen);

        if (detectionPlane.Raycast(detectionRay, out distance)) targetPosition = detectionRay.GetPoint(distance);

        Debug.Log("Mouse Position: " + targetPosition);

        currentPosition = transform.position;
        targetPosition.z = currentPosition.z + rollingSpeed;

        var delta = Time.deltaTime * Vector3.Distance(currentPosition, targetPosition);

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, delta);
        playerRB.velocity = transform.forward * rollingSpeed;
    }

    private void KeyboardControls() 
    {

    }
}
