using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    delegate void LeverDelegate(Transform point);
    LeverDelegate leverFunctions;
    public GameObject toolTipStats;

    public Light pointLight;
    public PlatformController platform;
    public GameObject leverUp, leverDown;
    public Transform waypoint;
    AudioSource audioSource;
    public AudioClip leverSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Adds function to delegate
        leverFunctions = ChangePlatformRoute;
        //Set lever down pose invisible
        leverDown.SetActive(false);
        //Set pointlight to inactive
        pointLight.enabled = false;

        toolTipStats.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //If the player is near the lever
        if (other.gameObject.CompareTag("Player"))
        {
            //Set pointlight to inactive
            pointLight.enabled = true;
            toolTipStats.SetActive(true);
            //If the player presses E, activate the lever
            if (Input.GetKeyDown(KeyCode.E)){
                leverUp.SetActive(false);
                leverDown.SetActive(true);

                audioSource.PlayOneShot(leverSound);
                //Uses a delegate to call ChangePlatformRoute
                leverFunctions(waypoint);
                //Set pointlight to inactive
                pointLight.enabled = false;
                toolTipStats.SetActive(false);
            }
        }
    }//end of OnTriggerStay

    private void OnTriggerExit(Collider other)
    {
        //Set pointlight to inactive
        pointLight.enabled = false;
        toolTipStats.SetActive(false);
    }//end of OnTriggerExit

    private void ChangePlatformRoute(Transform point)
    {
        //Adds a patrol point to the platform's navAI
        platform.AddPatrolPoint(point);
        Destroy(this);
    }//end of ChangePlatformRoute



}
