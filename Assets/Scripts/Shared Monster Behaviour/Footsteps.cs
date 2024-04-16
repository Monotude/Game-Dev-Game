using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private SoundEffect patrolFootsteps;
    [SerializeField] private SoundEffect chaseFootsteps;

    public void PlayPatrolFootstep()
    {
        patrolFootsteps.PlaySoundEffect();
    }

    public void PlayChaseFootstep()
    {
        chaseFootsteps.PlaySoundEffect();
    }
}
