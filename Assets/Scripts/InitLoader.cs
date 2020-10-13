using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitLoader : MonoBehaviour
{
    LoadingData gameData;

    void Start()
    {
        //If the player wants a game to load, start by trying to load the data
        if (!LocalData.startNewGame)
        {
            //Load game
            gameData = SaveSystem.instance.LoadGame();

            //If there is a save file
            if (gameData != null)
            {
                //Load the saved scene
                LocalData.NextSceneLoader(gameData.getSceneIndex());
            }

            //If not, a load file was not found. Just start a new game
            else
            {
                //Load first level
                LocalData.NextSceneLoader(3);
            }
        }

        //If the player wants a new game, simply load in the first level
        else
        {
            //Load first level
            LocalData.NextSceneLoader(3);
        }
    }

}
