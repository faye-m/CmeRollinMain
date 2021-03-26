using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject_CS : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerExit (Collider other) 
    {
        Destroy(gameObject);
    }
}
