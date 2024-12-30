using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    [SerializeField]
    private Slider soundSlider;

    [SerializeField]
    private AudioSource audio;

    [SerializeField, AllowsNull]
    private AudioSource? audioFxBomb;

    [SerializeField, AllowsNull]
    private AudioSource? audioFxGift;
    private void Start()
    {
        float soundVolume= PlayerPrefs.GetFloat("soundPref", 1);
        soundSlider.value = soundVolume;
        audio.volume = soundSlider.value/4;

        if(audioFxBomb != null)
        {
            audioFxBomb.volume = soundSlider.value;
        }

        if(audioFxGift != null)
        {
            audioFxGift.volume = soundSlider.value;
        }


    }

    public void ChangeSound()
    {
        float newValue = soundSlider.value;

        audio.volume = newValue / 4;

        if (audioFxBomb != null)
        {
            audioFxBomb.volume = soundSlider.value;
        }

        if (audioFxGift != null)
        {
            audioFxGift.volume = soundSlider.value;
        }

        PlayerPrefs.SetFloat("soundPref", newValue);
    }
}
