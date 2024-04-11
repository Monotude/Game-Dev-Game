using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    
    private Rigidbody rigidBody;
    private PlayerSprint playerSprint;
    private PlayerCrouch playerCrouch;
    [SerializeField] private GameObject player;

    public AudioSource AudioSource;
    public AudioClip ground;

    public float sprintFootstepInterval = 0.4f;
    public float defaultFootstepInterval = 0.8f; // Interval between footstep sounds in seconds

    private float footstepInterval;
    private float lastFootstepTime; // Time when the last footstep sound was played


    private void Start()
    {
        rigidBody = player.GetComponent<Rigidbody>();
        playerSprint = player.GetComponent<PlayerSprint>(); 
        playerCrouch = player.GetComponent<PlayerCrouch>();
    }


    void Update()
    {
        Vector3 velocity = rigidBody.velocity;

        if (playerCrouch.IsCrouching )
        {
            return;
        }
        

        if (velocity.magnitude > 0.1f)
        {
            footstepInterval = playerSprint.IsSprinting ? sprintFootstepInterval : defaultFootstepInterval;

            Footstep();
        }

    }

    public void Footstep()
    {
        // Check if enough time has elapsed since the last footstep sound
        if (Time.time - lastFootstepTime >= footstepInterval)
        {
            
            // Play footstep sound
            PlayFootStepSoundL(ground);

            // Update the last footstep time
            lastFootstepTime = Time.time;
           
        }
    }

    void PlayFootStepSoundL(AudioClip audio)
    {
        AudioSource.pitch = Random.Range(0.8f, 1f);
        AudioSource.PlayOneShot(audio);
    }
}
