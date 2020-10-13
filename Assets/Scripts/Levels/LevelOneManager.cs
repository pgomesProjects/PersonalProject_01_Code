using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelOneManager : MonoBehaviour
{

    public TextMeshProUGUI timerText, countText;

    //Items
    GameObject[] gameItems;
    private LoadingData saveData;

    void Start()
    {
        //New game data
        saveData = new LoadingData();
    }

    // Update is called once per frame
    void Update()
    {
        //Update in-game timer
        saveData = LocalData.UpdateTimer(saveData);

        //If there are less than 10 seconds in the minute, add a 0 to the front for the width to be consistent
        if (saveData.getSeconds() < 10)
            timerText.text = "" + saveData.getMinutes() + ":0" + saveData.getSeconds();

        else
            timerText.text = "" + saveData.getMinutes() + ":" + saveData.getSeconds();

        CheckKeyCollection();
        CheckWinState();
    }

    void CheckWinState()
    {
        gameItems = GameObject.FindGameObjectsWithTag("PickUp");

        //If all pick up items are inactive, change the scene
        if (gameItems.Length == 0)
        {
            //Save game data
            saveData.setSceneIndex(4);
            SaveSystem.instance.SaveGame(saveData);
            //Load next level
            LocalData.NextSceneLoader(4);
        }
    }//end of CheckWinState

    void CheckKeyCollection()
    {
        if (LocalData.keyCollected)
        {
            saveData.setKeys(saveData.getKeys() + 1);
            countText.text = "Keys: " + saveData.getKeys().ToString();
            LocalData.keyCollected = false;
        }
    }//end of CheckKeyCollection

}
