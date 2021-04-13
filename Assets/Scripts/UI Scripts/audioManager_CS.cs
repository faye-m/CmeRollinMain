using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager_CS : MonoBehaviour
{
    [SerializeField] private AudioMixer audMixer = null;
    [SerializeField] private AudioSource clickAudio = null;

    // Start is called before the first frame update
    void Start()
    {
        audMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        audMixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume"));
        audMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
    }

    public void PlaySFXAudio() 
    {
        clickAudio.Play();
    }
}
