using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformBehavior : MonoBehaviour
{
    public NavMeshAgent platformMovement;
    CharacterController controller;

    void Start()
    {
   
    }
    private void OnTriggerEnter(Collider other)
    {
        //When the player gets onto the moving platform, get their controller
        if (other.gameObject.CompareTag("Player"))
        {
            controller = other.GetComponent<CharacterController>();
        }   
    }//end of OnTriggerEnter

    private void OnTriggerStay(Collider other)
    {
        //While on the platform, move the player
        if (other.gameObject.CompareTag("Player"))
        {
            _ = controller.Move(platformMovement.velocity * Time.deltaTime);
        }
    }//end of OnTriggerExit
}
