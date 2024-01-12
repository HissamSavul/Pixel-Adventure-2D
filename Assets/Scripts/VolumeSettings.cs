using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myPlayer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start() {
        if(PlayerPrefs.HasKey("SavedMusicVolume")){
            LoadSavedVolume();
        }
        else {
            MusicVolumeSettings();
            SFXVolumeSettings();
        }
    }
    public void MusicVolumeSettings(){
        float volume = musicSlider.value;
        myPlayer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SavedMusicVolume",volume);
    }
    public void SFXVolumeSettings(){
        float volume = sfxSlider.value;
        myPlayer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SavedSFXVolume",volume);
    }

    private void LoadSavedVolume(){
        musicSlider.value = PlayerPrefs.GetFloat("SavedMusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SavedSFXVolume");
        MusicVolumeSettings();
        SFXVolumeSettings();
    }
}
