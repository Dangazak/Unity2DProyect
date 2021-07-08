using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider, soundVolumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            AudioManager.instance.SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        }
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("SoundVolume");
            AudioManager.instance.SetSoundVolume(PlayerPrefs.GetFloat("MusicVolume"));
        }
    }
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("SoundVolume");

        }
    }

    public void ResetRecord()
    {
        PlayerPrefs.SetInt("Record", 0);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        AudioManager.instance.SetMusicVolume(volume);
    }

    public void SetSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat("SoundVolume", volume);
        AudioManager.instance.SetSoundVolume(volume);
    }
}
