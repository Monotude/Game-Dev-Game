using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStepSounds : MonoBehaviour
{
    public AudioSource AudioSource;
    
    public AudioClip ground;

    RaycastHit hit;
    public Transform RayStart;
    public float range;
    public LayerMask layerMask;

     public float sprintFootstepInterval = 0.4f; 
    public float defaultFootstepInterval = 0.8f; // Interval between footstep sounds in seconds
    
     private float footstepInterval;
    private float lastFootstepTime; // Time when the last footstep sound was played


    void Update()
    {
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {   
           if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                footstepInterval = sprintFootstepInterval;
            }
            else
            {
                footstepInterval = defaultFootstepInterval;
            }

            // Call Footstep method as long as any of the movement keys are held down
            Footstep();
        }
    }


    public void Footstep() {
         // Check if enough time has elapsed since the last footstep sound
        if (Time.time - lastFootstepTime >= footstepInterval)
       {
            // Cast a ray downwards from rayStart to detect ground
           // if (Physics.Raycast(rayStart.position, -transform.up, out RaycastHit hit, range, layerMask))
           // {
                // Check if the object hit is tagged as "Ground"
               // if (hit.collider.CompareTag("Ground"))
              //  {
                    // Play footstep sound
                    PlayFootStepSoundL(ground);
                    // Update the last footstep time
                    lastFootstepTime = Time.time;
            //    }
          //  }
        }
    }

    void PlayFootStepSoundL (AudioClip audio) {
        AudioSource.pitch = Random.Range(0.8f, 1f);
        AudioSource.PlayOneShot(audio);
    }
}
