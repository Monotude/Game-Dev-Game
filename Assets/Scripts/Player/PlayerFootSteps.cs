using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] playerFootsteps;
    [SerializeField] private float walkingFootstepInterval;
    [SerializeField] private float walkingFootstepLoudness;
    [SerializeField] private float sprintFootstepInterval;
    [SerializeField] private float sprintFootstepLoudness;
    private Rigidbody rigidBody;
    private PlayerSprint playerSprint;
    private PlayerCrouch playerCrouch;
    private PlayerSound playerSound;
    private AudioSource audioSource;
    private float footstepInterval;
    private float lastFootstepTime;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerSprint = GetComponent<PlayerSprint>();
        playerCrouch = GetComponent<PlayerCrouch>();
        playerSound = GetComponent<PlayerSound>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 velocity = rigidBody.velocity;

        if (playerCrouch.IsCrouching)
        {
            return;
        }


        if (velocity.magnitude > 0.1f)
        {
            footstepInterval = playerSprint.IsSprinting ? sprintFootstepInterval : walkingFootstepInterval;
            float loudness = playerSprint.IsSprinting ? sprintFootstepLoudness : walkingFootstepLoudness;
            Footstep(loudness);
        }
    }

    public void Footstep(float loudness)
    {
        // Check if enough time has elapsed since the last footstep sound
        if (Time.time - lastFootstepTime >= footstepInterval)
        {
            playerSound.MakeSoundEvent?.Invoke(loudness, transform.position);

     

            // Update the last footstep time
            lastFootstepTime = Time.time;

        }
    }

    private void PlayFootstepSound(AudioClip audio)
    {
        audioSource.pitch = Random.Range(0.9f, 1.2f);
        audioSource.PlayOneShot(audio);
    }
}
