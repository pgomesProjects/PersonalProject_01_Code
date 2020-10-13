using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{

    public GameObject titleScreenUI, optionsUI;
    public AudioSource music;
    public AudioClip testSound;

    private float testSoundtimer;
    private bool playTestSound = false;

    public void ChangeMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVol", value);
        music.volume = value;
        Debug.Log("Music Volume: " + music.volume);
    }//end of ChangeMusicVolume

    public void ChangeSoundVolume(float value)
    {
        PlayerPrefs.SetFloat("SoundVol", value);
    }//end of ChangeSoundVolume

    public void StartTestSound()
    {
        playTestSound = true;
    }//end of StartTestSound

    public void StopTestSound()
    {
        playTestSound = false;
    }//end of StopTestSound

    void Update()
    {
        if (playTestSound)
            TestSoundVolume();
    }

    void TestSoundVolume()
    {
        Debug.Log("Testing Sound Volume...");
        testSoundtimer += Time.deltaTime;
        if (testSoundtimer >= 0.5f)
        {
            music.PlayOneShot(testSound, PlayerPrefs.GetFloat("SoundVol"));
            testSoundtimer = 0;
        }
    }//end of TestSoundVolume

    public void BackToTitle()
    {
        //Show main menu screen, hide options menu
        optionsUI.SetActive(false);
        titleScreenUI.SetActive(true);
    }//end of BackToTitle
}
