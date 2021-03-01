using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraMovement_CS : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private string playerTag = "Player";
    private Vector3 currentPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    private void Awake() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    private void CameraMovement() 
    {
        playerTransform = GameObject.FindWithTag(playerTag).transform;

        targetPosition = playerTransform.position;
        currentPosition = this.transform.position;

        var delta = Time.deltaTime * Vector3.Distance(currentPosition, targetPosition);

        transform.position = Vector3.Lerp(currentPosition, targetPosition, delta*3);
    }
}
