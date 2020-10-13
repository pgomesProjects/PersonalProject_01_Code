using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject titleScreenUI, optionsUI;
    public Slider musicSlider;
    public Slider soundSlider;

    void Awake()
    {
        //The title screen will always be seen first, so immediately hide options menu when created
        optionsUI.SetActive(false);

        //If both PlayerPrefs start at 0, set them to 0.5f by default
        if (PlayerPrefs.GetFloat("MusicVol") == 0 && PlayerPrefs.GetFloat("SoundVol") == 0)
        {
            PlayerPrefs.SetFloat("MusicVol", 0.5f);
            PlayerPrefs.SetFloat("SoundVol", 0.5f);
        }

        //Set any existing PlayerPrefs
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        soundSlider.value = PlayerPrefs.GetFloat("SoundVol");
    }

    public void NewGame()
    {
        //Start the game without loading data
        LocalData.startNewGame = true;
        LocalData.NextSceneLoader(1);
    }//end of NewGame

    public void LoadGame()
    {
        //Start the game by loading data
        LocalData.startNewGame = false;
        LocalData.NextSceneLoader(1);
    }//end of LoadGame

    public void Options()
    {
        //Show options menu, hide main menu screen
        optionsUI.SetActive(true);
        titleScreenUI.SetActive(false);
    }//end of Options

    public void QuitGame()
    {
        Application.Quit();
    }//end of QuitGame
}
