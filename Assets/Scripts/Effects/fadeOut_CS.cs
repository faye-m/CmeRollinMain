using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut_CS : MonoBehaviour
{
    [SerializeField] private Material material = null;
    private bool isFading = false;
    private float fade;
    [SerializeField] private float fadeSpeedMultiplier = 2f;
    [SerializeField] private GameObject parent = null;
    [SerializeField] private Collider objCollider = null;
    [SerializeField] private GameObject obtainItemPrompt = null;
    [SerializeField] private hatAnimation_CS hatAnim = null;
    [SerializeField] private float displayTime = 5f;
    private float currentTime = 0f;

    private void Awake() 
    {
        if (material == null) material = GetComponent<SpriteRenderer>().material;
        fade = material.GetFloat("_Fade");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading) 
        {
            currentTime += Time.deltaTime;
            objCollider.enabled = false;
            fade -= Time.deltaTime * fadeSpeedMultiplier;
            if (fade <= 0f) 
            {
                //isFading = false;
                fade = 1.5f;
                material.SetFloat("_Fade", fade);
                Destroy(parent);
            }

            material.SetFloat("_Fade", fade);
        }

        if (obtainItemPrompt != null && obtainItemPrompt.activeSelf && currentTime >= displayTime) obtainItemPrompt.SetActive(false);
    }

    public void SetBool(bool condition) 
    {
        isFading = condition;
    }

    public void SetPromptActive() 
    {
        if (obtainItemPrompt != null) obtainItemPrompt.SetActive(true);       
    }
}
