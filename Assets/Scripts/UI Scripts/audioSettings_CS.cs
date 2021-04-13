using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; 

public class audioSettings_CS : MonoBehaviour
{
    [SerializeField] private AudioMixer audMixer = null;
    [SerializeField] private AudioSource sfxAudioSource = null;
    private bool valueChanged = false;

    [SerializeField] private Toggle masterToggle = null, bgmToggle = null, sfxToggle = null;
    [SerializeField] private Slider masterSlider = null, bgmSlider = null, sfxSlider = null;
    //[SerializeField] private Image masterMImage = null, bgmMImage = null, sfxMImage = null;
    //[SerializeField] private Sprite[] volumeSprites = null;
    private float minValue = -50f, defaultValue = 0f;

    private void Awake() 
    {

    }

    private void Start() 
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        
        if (masterSlider.value <= minValue) masterToggle.isOn = true;
        if (bgmSlider.value <= minValue) bgmToggle.isOn = true;
        if (sfxSlider.value <= minValue) sfxToggle.isOn = true;
    }

    private void Update() 
    {
        if (!sfxAudioSource.isPlaying && valueChanged) 
        {
            sfxAudioSource.Play();
            valueChanged = false;
        }
    }

    public void SetMasterLevel(float sliderValue) 
    {
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
        audMixer.SetFloat("MasterVolume", sliderValue);

        if (sliderValue <= minValue) masterToggle.isOn = true;
        else masterToggle.isOn = false;
    }

    public void SetBGMLevel(float sliderValue) 
    {
        PlayerPrefs.SetFloat("BGMVolume", sliderValue);
        audMixer.SetFloat("BGMVolume", sliderValue);

        if (sliderValue <= minValue) bgmToggle.isOn = true;
        else bgmToggle.isOn = false;
    }

    public void SetSFXLevel(float sliderValue) 
    {
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
        audMixer.SetFloat("SFXVolume", sliderValue);
        valueChanged = true;

        if (sliderValue <= minValue) sfxToggle.isOn = true;
        else sfxToggle.isOn = false;
    }

    public void ToggleMasterMute () 
    {
        if (masterToggle.isOn) 
        {
            masterSlider.value = minValue;
            bgmSlider.value = minValue;
            sfxSlider.value = minValue;
        }

        else 
        {
            masterSlider.value = defaultValue;
            bgmSlider.value = defaultValue;
            sfxSlider.value = defaultValue;
        }

        bgmToggle.isOn = masterToggle.isOn;
        sfxToggle.isOn = masterToggle.isOn;
    }

    public void ToggleBGMMute() 
    {
        if (bgmToggle.isOn) 
        {
            bgmSlider.value = minValue;
        }

        else 
        {
            bgmSlider.value = defaultValue;
        }
    }

    public void ToggleSFXMute() 
    {
        if (sfxToggle.isOn) 
        {
            sfxSlider.value = minValue;
        }

        else 
        {
            sfxSlider.value = defaultValue;
        }
    }
}
