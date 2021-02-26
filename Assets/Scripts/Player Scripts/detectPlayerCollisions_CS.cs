using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayerCollisions_CS : MonoBehaviour
{
    //declare variables
    [SerializeField] private string obstacleTag = "obstacle";
    [SerializeField] private string passTag = "hallPass";
    [SerializeField] private string finishLineTag = "goal";

    private void OnTriggerEnter (Collider other) 
    {
        if (other.tag == obstacleTag) 
        {
            Debug.Log("Player loses one life or enters Game Over when the lives reach 0");
            //play animations involved
        }

        if (other.tag == passTag) 
        {
            Debug.Log("Player obtains a hall pass");
            //call related UI and Particle Animations here
        }

        if (other.tag == finishLineTag) 
        {
            Debug.Log("Player wins the level, CONGRATS!");
            //play animations involved
        }
    }
}
