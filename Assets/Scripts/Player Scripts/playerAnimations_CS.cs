using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations_CS : MonoBehaviour
{
    [SerializeField] private Animator playerAnim = null, chairAnim = null;
    [SerializeField] private GameObject dizzyPFX = null;
    private float dizzyTime = 2f;
    private float currentTime;
    private bool isDizzy = false;

    private void FixedUpdate() 
    {
        if (isDizzy) 
        {
            currentTime += Time.fixedDeltaTime;
            Debug.Log("Time Player is Dizzy - " + currentTime);
            if (currentTime >= dizzyTime) 
            {
                dizzyPFX.SetActive(false);
                currentTime = 0;
                isDizzy = false;
            }
        }
    }

    // Start is called before the first frame update
    public void TurningRight() 
    {
        playerAnim.SetBool("LeaningRight", true);
        playerAnim.SetBool("LeaningLeft", false);
        playerAnim.SetBool("GoingForward", false);
    }

    public void TurningLeft() 
    {
        playerAnim.SetBool("LeaningRight", false);
        playerAnim.SetBool("LeaningLeft", true);
        playerAnim.SetBool("GoingForward", false);
    }

    public void PlayerGetsHit() 
    {
        playerAnim.Play("Base Layer.Player_HitAnim");
        chairAnim.Play("Base Layer.CHAIR_HitAnim");
        playerAnim.SetBool("LeaningRight", false);
        playerAnim.SetBool("LeaningLeft", false);
        playerAnim.SetBool("GoingForward", true);
        dizzyPFX.SetActive(true);
        isDizzy = true;
        currentTime = 0;
    }

    public void GoingForward() 
    {
        playerAnim.SetBool("LeaningRight", false);
        playerAnim.SetBool("LeaningLeft", false);
        playerAnim.SetBool("GoingForward", true);
        Debug.Log("Forward Motion is Playing");
    }

    public void PlayerLoses() 
    {
        playerAnim.Play("Base Layer.DejectedAnim");
    }


}
