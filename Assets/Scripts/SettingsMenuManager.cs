using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public Slider MusicSlider;
    public Slider SoundFXSlider;

    private void Start()
    {
        // Set the volume of the sliders based on the saved values
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        audioMixer.GetFloat("SoundVolume", out float soundVolume);

        MusicSlider.value = musicVolume;
        SoundFXSlider.value = soundVolume;
    }
    
    public void SetSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
    }
    
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void OnClickBack()
    {
        // Activate the previous scene
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
    }
}
