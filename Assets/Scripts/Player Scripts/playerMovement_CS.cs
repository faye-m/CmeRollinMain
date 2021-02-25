using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement_CS : MonoBehaviour
{
    //instantiate variables here
    private Vector3 fingerPosition;
    private Vector3 direction;
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float slidingSpeed = 20f;

    private Rigidbody playerRB;  

    private void Awake() 
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update() 
    {

    }

    //detect player inputs
    private void DetectPlayerInputCommands() 
    {
        //detects if there 1 or more fingers on screen and takes the touch position of the very first touch instance
        if (Input.touchCount > 0) 
        {
            Touch singleTouch = Input.GetTouch(0);
            Debug.Log("Current Touch Position: " + singleTouch.position);

            //get finger position in relation to screen
            fingerPosition = Camera.main.ScreenToWorldPoint(singleTouch.position);
            
            //set z and y position to 0 since it's irrelevant to the sideward movement
            fingerPosition.z = 0;
            fingerPosition.y = 0;

            direction = (fingerPosition - transform.position);
        }

        // keyboard command option for PC/Web
        else if (Input.GetAxis("Horizontal") != 0) 
        {

        }
    }
}
