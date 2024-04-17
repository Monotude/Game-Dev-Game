using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerSprint playerSprint;
    private PlayerCrouch playerCrouch;
    private AudioSource audioSource;
    private PlayerSound playerSound;
    private float timeUntilFootstep;
    [SerializeField] private AudioClip[] playerFootsteps;
    [SerializeField] private float walkingFootstepInterval;
    [SerializeField] private float walkingFootstepLoudness;
    [SerializeField] private float sprintFootstepInterval;
    [SerializeField] private float sprintFootstepLoudness;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerSprint = GetComponent<PlayerSprint>();
        playerCrouch = GetComponent<PlayerCrouch>();
        audioSource = GetComponent<AudioSource>();
        playerSound = GetComponent<PlayerSound>();
    }

    private void Update()
    {
        Vector3 velocity = rigidBody.velocity;

        if (velocity.magnitude > 0.1f && !playerCrouch.IsCrouching)
        {
            float interval = playerSprint.IsSprinting ? sprintFootstepInterval : walkingFootstepInterval;
            float loudness = playerSprint.IsSprinting ? sprintFootstepLoudness : walkingFootstepLoudness;
            Footstep(interval, loudness);
        }

        else
        {
            timeUntilFootstep = 0f;
        }
    }

    public void Footstep(float interval, float loudness)
    {
        timeUntilFootstep += Time.deltaTime;

        if (timeUntilFootstep >= interval)
        {
            timeUntilFootstep = 0;
            playerSound.MakeSoundEvent?.Invoke(loudness, transform.position);
            PlayFootstepSound();
        }
    }

    private void PlayFootstepSound()
    {
        int randomSound = Random.Range(0, playerFootsteps.Length);
        audioSource.pitch = Random.Range(0.9f, 1.2f);
        audioSource.PlayOneShot(playerFootsteps[randomSound]);
    }
}
