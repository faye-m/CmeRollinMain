using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinObject_CS : MonoBehaviour
{
    [SerializeField] private Transform objectTransform = null;
    [SerializeField] private float rotationSpeed = 75f;

    [SerializeField] private float timer = 1f;
    private float currentTime = 0f; 


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer) objectTransform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.Self);
    }

}
