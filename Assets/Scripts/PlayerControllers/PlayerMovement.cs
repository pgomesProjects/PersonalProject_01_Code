using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Controls the movement of the player
//Tutorial found from Brackeys YouTube Channel (https://www.youtube.com/watch?v=_QajrabyTJc)
public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public TextMeshProUGUI countText;

    public float speed = 4f;
    public float run = 7f;
    public float crouchSpeed = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck, spawnLoc;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    AudioSource audioSource;
    //Player Audio Sources
    public AudioClip collectSound;

    Vector3 velocity;
    bool isGrounded;
    float tempSpeed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tempSpeed = speed;
    }

    void Update()
    {

        //Creates a sphere with a specified radius (groundDistance) and checks to see if its colliding with the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If the player is on the ground and the velocity is less than 0, reset the velocity so it isn't constantly building up
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Moves the x and z relative to the player
        //If it were not done like this, it would be done globally, which is not what we want
        Vector3 move = transform.right * x + transform.forward * z;

        //Move, but use delta time to ensure the movement is frame independent (speed doesn't rely on the frames)
        controller.Move(move * speed * Time.deltaTime);

        //Check to see if the player can jump
        JumpCheck();

        //Check to see if the player can run
        SprintCheck();

        velocity.y += gravity * Time.deltaTime;

        //Gravity based on the velocity given
        controller.Move(velocity * Time.deltaTime);
    }

    void JumpCheck()
    {
        //If jump button is pressed, have the player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Physics equation for jumping a specific amount of units: square root of the units wanted * -2 * the gravitational force
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }//end of JumpCheck

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            LocalData.keyCollected = true;
            audioSource.PlayOneShot(collectSound, PlayerPrefs.GetFloat("SoundVol"));//Plays the sound effect once
        }

        //If player collides with this object, respawn them to their spawn point
        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Respawning...");
            //Turn off character controller, since this overrides any transforms made
            controller.enabled = false;
            this.transform.position = new Vector3(spawnLoc.position.x, spawnLoc.position.y, spawnLoc.position.z);
            controller.enabled = true;
        }

    }//end of OnTriggerEnter

    void SprintCheck()
    {

        //If the sprint button is held, change the speed of the player
        speed = Input.GetKey(KeyCode.LeftShift) ? run : tempSpeed;

    }//end of SprintCheck
}
