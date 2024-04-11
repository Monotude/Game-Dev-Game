using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource AudioSource;
    private AudioClip ground;
    private float sprintFootstepInterval = 0.4f;
    private float defaultFootstepInterval = 0.8f; // Interval between footstep sounds in seconds
    private float footstepInterval;
    private float lastFootstepTime; // Time when the last footstep sound was played



    private void Update()
    {
        if (true)
        {
            footstepInterval = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? sprintFootstepInterval : defaultFootstepInterval;

            // Call Footstep method as long as any of the movement keys are held down
            Footstep();
        }
    }


    public void Footstep()
    {
        // Check if enough time has elapsed since the last footstep sound
        if (Time.deltaTime - lastFootstepTime >= footstepInterval)
        {
            // Cast a ray downwards from rayStart to detect ground
            // if (Physics.Raycast(rayStart.position, -transform.up, out RaycastHit hit, range, layerMask))
            // {
            // Check if the object hit is tagged as "Ground"
            // if (hit.collider.CompareTag("Ground"))
            //  {
            // Play footstep sound
            PlayFootstepSound(ground);
            // Update the last footstep time
            lastFootstepTime = Time.time;
            //    }
            //  }
        }
    }

    private void PlayFootstepSound(AudioClip audio)
    {
        AudioSource.pitch = Random.Range(0.9f, 1.2f);
        AudioSource.PlayOneShot(audio);
    }
}
