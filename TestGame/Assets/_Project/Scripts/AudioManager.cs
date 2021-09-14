using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private Slider musicSlider, soundSlider;
    private AudioSource musicSrc, soundSrc;
    float musicVol = 1f;
    float soundVol = 1f;

    bool findMSlider;   //check music slider
    bool findSSlider;   //check sound slider
    bool findMSrc;   //check music source
    bool findSSrc;   //check sound source

    private void Awake()
    {
        findMSlider = GameObject.Find("MusicSlider");
        findSSlider = GameObject.Find("SoundSlider");
        findMSrc = GameObject.FindGameObjectWithTag("BgMusic");
        findSSrc = GameObject.FindGameObjectWithTag("Sound");

        if (findMSlider)
            musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        if(findSSlider)
            soundSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();

        if (findMSrc)
            musicSrc = GameObject.FindGameObjectWithTag("BgMusic").GetComponent<AudioSource>();
        if(findSSrc)
            soundSrc = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();

    }

    private void Start()
    {
        if(findMSlider && findMSrc)
        musicSlider.value = musicSrc.volume;
        if(findSSlider && findSSrc)
        soundSlider.value = soundSrc.volume;
    }

    private void Update()
    {
        if(musicSrc!=null)
            musicSrc.volume = PlayerPrefs.GetFloat("musicVol");
        if (soundSrc != null)
            soundSrc.volume = PlayerPrefs.GetFloat("soundVol");
    }

    public void MusicVolControl()
    {
        musicVol = musicSlider.value;
        PlayerPrefs.SetFloat("musicVol", musicVol);
    }

    public void SoundVolControl()
    {
        soundVol = soundSlider.value;
        PlayerPrefs.SetFloat("soundVol", soundVol);
    }
}
