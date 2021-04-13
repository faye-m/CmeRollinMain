using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class scaleObjectTween_CS : MonoBehaviour
{
    [SerializeField] private float delay = 0f;
    [SerializeField] private float duration = 0.25f;
    public LeanTweenType inType, outType;
    [SerializeField] private Vector3 scaleIn = new Vector3( 1f, 1f, 1f);
    [SerializeField] private Vector3 scaleOut = new Vector3( 0f, 0f, 0f);

    public void OnEnable() 
    {
        transform.localScale = scaleOut;
        LeanTween.scale(gameObject, scaleIn, duration).setDelay(delay).setEase(inType);
    }

    public void OnClose() 
    {
        LeanTween.scale(gameObject, scaleOut, duration).setDelay(delay).setEase(outType);
    }
    
}
