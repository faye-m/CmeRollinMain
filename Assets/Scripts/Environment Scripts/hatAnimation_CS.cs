using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatAnimation_CS : MonoBehaviour
{
    [SerializeField] private int hatNumber = 0;
    [SerializeField] private Transform hatTransform = null;
    [SerializeField] private float rotationSpeed = 75f;
    [SerializeField] private float minY = 1f, maxY = 2f;
    private bool goingUp = true;
    [SerializeField] private float speed = 1f;

    void FixedUpdate()
    {
        RotateHat();
        UpDownHatMovement();
    }

    private void RotateHat() 
    {
        hatTransform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.Self);
    }

    private void UpDownHatMovement() 
    {
        if (hatTransform.position.y >= maxY) goingUp = false;
        else if (hatTransform.position.y <= minY) goingUp = true;

        if (goingUp) hatTransform.position = Vector3.MoveTowards(hatTransform.position, new Vector3(hatTransform.position.x, maxY, 
                    hatTransform.position.z), speed * Time.deltaTime);
        else if (!goingUp) hatTransform.position = Vector3.MoveTowards(hatTransform.position, new Vector3(hatTransform.position.x, minY, 
                    hatTransform.position.z), speed * Time.deltaTime);
        
    }

    public void AddHat() 
    {
        string hatLabel = "HatOption" + hatNumber.ToString() + "Unlocked";
        PlayerPrefs.SetInt(hatLabel, 1); 
    }

    public int GetHatNumber() 
    {
        return hatNumber;
    }

    // helihat - 1 sodahat - 2 sunhat - 3 partyhat - 4
}
