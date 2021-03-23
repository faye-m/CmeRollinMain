using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlayerLooks_CS : MonoBehaviour
{
    [SerializeField] private GameObject[] hats = null;
    private int activeHatNumber = 0;

    private void Awake() 
    {
        activeHatNumber = PlayerPrefs.GetInt("ActiveHat");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        hats[activeHatNumber].SetActive(true);   
    }

}
