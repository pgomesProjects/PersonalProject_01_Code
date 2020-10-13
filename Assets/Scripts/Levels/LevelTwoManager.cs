using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTwoManager : MonoBehaviour
{

    public TextMeshProUGUI timerText, countText, statsText;
    public GameObject uiStats, winStats;

    //Items
    GameObject[] gameItems;
    private LoadingData saveData;

    void Start()
    {
        //Load level info
        saveData = SaveSystem.instance.LoadGame();

        countText.text = "Keys: " + saveData.getKeys().ToString();
        winStats.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!LocalData.gameWon)
        {
            //Update in-game timer
            saveData = LocalData.UpdateTimer(saveData);
        }

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
            LocalData.gameWon = true;
            uiStats.SetActive(false);
            GetStats();
            winStats.SetActive(true);
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

    void GetStats()
    {
        //If there are less than 10 seconds in the minute, add a 0 to the front for the width to be consistent
        if (saveData.getSeconds() < 10)
            statsText.text = "Time Completed: " + saveData.getMinutes() + ":0" + saveData.getSeconds();

        else
            statsText.text = "Time Completed: " + saveData.getMinutes() + ":" + saveData.getSeconds();
    }//end of GetStats
}
