using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFX_DizzyRotation : MonoBehaviour
{
    
    [SerializeField] Vector3 speed = new Vector3(0,150,0);

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}



