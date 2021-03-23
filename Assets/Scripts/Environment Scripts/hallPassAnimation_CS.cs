using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallPassAnimation_CS : MonoBehaviour
{
    [SerializeField] private Transform hallPassTransform = null;
    [SerializeField] private float rotationSpeed = 75f;
    [SerializeField] private float minY = 1f, maxY = 2f;
    private bool goingUp = true;
    [SerializeField] private float speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        RotatePass();
        UpDownPassMovement();
    }

    private void RotatePass() 
    {
        hallPassTransform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.Self);
    }

    private void UpDownPassMovement() 
    {
        if (hallPassTransform.position.y >= maxY) goingUp = false;
        else if (hallPassTransform.position.y <= minY) goingUp = true;

        if (goingUp) hallPassTransform.position = Vector3.MoveTowards(hallPassTransform.position, new Vector3(hallPassTransform.position.x, maxY, 
                    hallPassTransform.position.z), speed * Time.deltaTime);
        else if (!goingUp) hallPassTransform.position = Vector3.MoveTowards(hallPassTransform.position, new Vector3(hallPassTransform.position.x, minY, 
                    hallPassTransform.position.z), speed * Time.deltaTime);
        
    }
}
