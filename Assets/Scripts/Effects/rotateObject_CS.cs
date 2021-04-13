using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject_CS : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        float rotY = this.transform.rotation.y + rotSpeed;
        transform.Rotate(0f, rotY, 0f, Space.Self); 
    }
}
