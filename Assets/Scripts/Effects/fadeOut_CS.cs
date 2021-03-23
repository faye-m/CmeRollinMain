using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut_CS : MonoBehaviour
{
    private Material material;
    private bool isFading = false;
    private float fade;
    [SerializeField] private float fadeSpeedMultiplier = 2f;
    [SerializeField] private GameObject parent;
    [SerializeField] private Collider collider = null;

    private void Awake() 
    {
        material = GetComponent<SpriteRenderer>().material;
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
            collider.enabled = false;
            fade -= Time.deltaTime * fadeSpeedMultiplier;
            if (fade <= 0f) 
            {
                isFading = false;
                material.SetFloat("_Fade", fade);
                Destroy(parent);
            }

            material.SetFloat("_Fade", fade);
        }
    }

    public void SetBool(bool condition) 
    {
        isFading = condition;
    }
}
