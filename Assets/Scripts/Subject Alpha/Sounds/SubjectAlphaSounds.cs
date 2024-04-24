using UnityEngine;

public class SubjectAlphaSounds : MonoBehaviour
{
    private StateMachine stateMachine;
    [SerializeField] private SoundEffect monsterScreams;
    [SerializeField] private SoundEffect monsterHitScreams;

    private void Start()
    {
        stateMachine = GetComponent<SubjectAlphaBehaviour>().StateMachine;
        stateMachine.ChangeStateEvent += PlayStateSound;
    }

    public void PlayMonsterScream()
    {
        monsterScreams.PlaySoundEffect();
    }

    public void PlayMonsterHitScream()
    {
        monsterHitScreams.PlaySoundEffect();
    }

    private void PlayStateSound(State state)
    {
        if (state is ChaseState)
        {
            PlayMonsterScream();
            AudioManager.Instance.PlayMusic("Section 1 Chase");
        }

        else if (state is FleeState)
        {
            AudioManager.Instance.PlayMusic("Section 1 Horror");
        }
    }
}
