using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    //Play the music globally between scenes
    //Only one instance allowed
    //Reference used for script: https://www.youtube.com/watch?v=i0coh71r-v8
    private static BGMController instance = null;

    AudioSource audioSource;

    public static BGMController Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        //If there are any other existing instances, destroy them
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("MusicVol");

        //Makes sure that the game object doesn't get destroyed when changing scenes
        DontDestroyOnLoad(this.gameObject);
    }

}
