using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LocalData
{
    public static bool startNewGame = false;

    public static bool gameWon = false;
    public static bool keyCollected = false;
    public static int sceneToLoad;

    public static LoadingData UpdateTimer(LoadingData gameData)
    {
        gameData.setTimer(gameData.getTimer() + Time.deltaTime);
        gameData.setSeconds((int)(gameData.getTimer() % 60));

        //If the seconds are equal to or more than 60, a minute has passed. Update accordingly
        if (gameData.getTimer() >= 60)
        {
            gameData.setTimer(0);
            gameData.setMinutes(gameData.getMinutes() + 1);
        }

        return gameData;

    }//end of UpdateTimer

    public static void NextSceneLoader(int sceneToLoad)
    {
        //Name of scene to load
        LocalData.sceneToLoad = sceneToLoad;
        //Make a loading screen while it loads
        SceneManager.LoadScene(2);
    }//end of NextSceneLoader

}
