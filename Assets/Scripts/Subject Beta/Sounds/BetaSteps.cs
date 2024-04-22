using UnityEngine;

public class BetaSteps : MonoBehaviour
{
    [SerializeField] private SoundEffect crawlFootsteps;
    [SerializeField] private SoundEffect aggroFootsteps;
    

    public void PlayRoamFootstep()
    {
        crawlFootsteps.PlaySoundEffect();
    }

    public void PlayAgroFootstep()
    {
        aggroFootsteps.PlaySoundEffect();
    }
}
