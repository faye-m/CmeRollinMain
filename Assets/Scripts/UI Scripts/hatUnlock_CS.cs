using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hatUnlock_CS : MonoBehaviour
{
    [SerializeField] private int hatNumber = 0;
    [SerializeField] private Image lockImage = null, hatImg = null;
    [SerializeField] private Sprite[] hatSprites = null;
    [SerializeField] private Button hatButton = null;

    // Start is called before the first frame update
    void Start()
    {
        string hatLabel = "HatOption" + hatNumber.ToString() + "Unlocked";
        int hatUnlocked = PlayerPrefs.GetInt(hatLabel);

        hatImg.sprite = hatSprites[hatNumber];

        if (hatUnlocked == 0 && hatNumber != 0) 
        {
            lockImage.enabled = true;
            hatButton.enabled = false;
            hatImg.color = Color.grey;
        }

        else if (hatNumber == 0) 
        {
            lockImage.enabled = false;
            hatButton.enabled = true;
            hatImg.color = Color.red;
        }   

        else 
        {
            lockImage.enabled = false;
            hatButton.enabled = true;
            hatImg.color = Color.white;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerCap() 
    {
        PlayerPrefs.SetInt("ActiveHat", hatNumber);
    }
}
