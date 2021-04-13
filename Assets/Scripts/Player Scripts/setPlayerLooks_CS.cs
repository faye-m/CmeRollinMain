using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlayerLooks_CS : MonoBehaviour
{
    [SerializeField] private GameObject[] customHatsM = null;
    [SerializeField] private GameObject[] customHatsF = null;
    [SerializeField] private GameObject girlItems = null, boyItems = null;
    [SerializeField] private Texture[] playerTextures = null;
    [SerializeField] private Renderer playerRenderer = null;
    private int activeHatNumber = 0;
    [SerializeField] private bool isMale = true;
    [SerializeField] private bool onDisplayScene = false;
    private int condition = 0;
    private int currentHatNumber;
    [SerializeField] private GameObject defaultCap = null;

    private void Awake() 
    {
        if (onDisplayScene) condition = PlayerPrefs.GetInt("AvatarGender");
        activeHatNumber = PlayerPrefs.GetInt("ActiveHat");
        switch (condition) 
        {
            case 2:
                isMale = false;
                break;
            case 1: 
                isMale = true;
                break;
            default: 
                break;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (isMale && customHatsM[activeHatNumber] != null) customHatsM[activeHatNumber].SetActive(true);
        else if (!isMale && customHatsF[activeHatNumber] != null) customHatsF[activeHatNumber].SetActive(true);
        
        if (isMale) 
        {
            boyItems.SetActive(true);
            girlItems.SetActive(false);
            playerRenderer.material.SetTexture("_MainTex", playerTextures[0]);
            condition = 1;

            if (activeHatNumber != 0) defaultCap.SetActive(false);
        }

        else 
        {
            boyItems.SetActive(false);
            girlItems.SetActive(true);
            playerRenderer.material.SetTexture("_MainTex", playerTextures[1]);
            condition = 2;
        }

        if (!onDisplayScene) PlayerPrefs.SetInt("AvatarGender", condition);
    }

    private void LateUpdate() 
    {
        currentHatNumber = PlayerPrefs.GetInt("ActiveHat");

        if (currentHatNumber != activeHatNumber && customHatsM[currentHatNumber] != null) 
        {
            if (currentHatNumber != 0 && isMale) defaultCap.SetActive(false);
            else if (isMale) defaultCap.SetActive(true);

            if (isMale) 
            { 
                customHatsM[activeHatNumber].SetActive(false);
                customHatsM[currentHatNumber].SetActive(true);
            }

            else 
            {
                customHatsF[activeHatNumber].SetActive(false);
                customHatsF[currentHatNumber].SetActive(true);
            }
            activeHatNumber = currentHatNumber;
        }

        if (isMale && !boyItems.activeSelf) 
        {
            boyItems.SetActive(true);
            girlItems.SetActive(false);
            playerRenderer.material.SetTexture("_MainTex", playerTextures[0]);

            if (activeHatNumber != 0) defaultCap.SetActive(false);

            customHatsF[activeHatNumber].SetActive(false);
            customHatsM[activeHatNumber].SetActive(true);
        }

        else if (!isMale && !girlItems.activeSelf)
        {
            boyItems.SetActive(false);
            girlItems.SetActive(true);
            playerRenderer.material.SetTexture("_MainTex", playerTextures[1]);

            customHatsM[activeHatNumber].SetActive(false);
            customHatsF[activeHatNumber].SetActive(true);
        }
    }

    public void ChangeCharacter() 
    {
        isMale = !isMale;
    }

}
