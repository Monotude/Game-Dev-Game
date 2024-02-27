using UnityEngine;

public class PlayMonsterFootsteps : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] patrolFootsteps;
    [SerializeField] private AudioClip[] chaseFootsteps;

    private void PlayPatrolFootstep()
    {
        audioSource.PlayOneShot(GetPatrolFootstep());
    }

    private void PlayChaseFootstep()
    {
        audioSource.PlayOneShot(GetChaseFootstep());
    }

    private AudioClip GetPatrolFootstep()
    {
        return patrolFootsteps[Random.Range(0, patrolFootsteps.Length)];
    }

    private AudioClip GetChaseFootstep()
    {
        return chaseFootsteps[Random.Range(0, chaseFootsteps.Length)];
    }
}
