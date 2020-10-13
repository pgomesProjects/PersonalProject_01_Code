using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Quit game if ESC is pressed
        if (Input.GetKey(KeyCode.Escape))
        {
            Invoke("QuitGame", 2f);
        }
    }

    void QuitGame()
    {
        Application.Quit();
    }//end of QuitGame

}
