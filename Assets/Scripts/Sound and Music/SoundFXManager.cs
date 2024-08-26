using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    public AudioSource CharacterSpeakingSound;
    public AudioSource ButtonClickSound;
    public AudioSource PickLetterSound;
    public AudioSource DropLetterSound;
    public AudioSource NewAchievementSound;
    public AudioSource FinishedGameSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayCharacterSpeakingSound()
    {
        CharacterSpeakingSound.Play();
    }

    public void StopCharacterSpeakingSound()
    {
        CharacterSpeakingSound.Stop();
    }

    public void PlayButtonClickSound()
    {
        ButtonClickSound.Play();
    }

    public void PlayNewAchievementSound()
    {
        NewAchievementSound.Play();
    }

    public void PlayPickLetterSound()
    {
        PickLetterSound.Play();
    }

    public void PlayDropLetterSound()
    {
        DropLetterSound.Play();
    }

    public void PlayFinishedGameSound()
    {
        FinishedGameSound.Play();
    }
}
