//Add this if the material in the class may be converted to binary at some point
//Useful for serializing in save data
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class LoadingData
{

    private float timer;
    private int minutes, seconds, keys;
    private int sceneIndex;

    public LoadingData()
    {
        this.timer = 0;
        this.minutes = 0;
        this.seconds = 0;
        this.keys = 0;
    }//end of LoadingData

    //Getters
    public float getTimer()
    {
        return this.timer;
    }

    public int getMinutes()
    {
        return this.minutes;
    }

    public int getSeconds()
    {
        return this.seconds;
    }
    public int getKeys()
    {
        return this.keys;
    }

    public int getSceneIndex()
    {
        return this.sceneIndex;
    }

    //Setters
    public void setTimer(float timer)
    {
        this.timer = timer;
    }

    public void setMinutes(int minutes)
    {
        this.minutes = minutes;
    }

    public void setSeconds(int seconds)
    {
        this.seconds = seconds;
    }

    public void setKeys(int keys)
    {
        this.keys = keys;
    }

    public void setSceneIndex(int sceneIndex)
    {
        this.sceneIndex = sceneIndex;
    }
}
