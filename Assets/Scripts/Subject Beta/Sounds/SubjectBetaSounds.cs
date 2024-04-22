using UnityEngine;

public class SubjectBetaSounds : MonoBehaviour
{
    private StateMachine stateMachine;
    [SerializeField] private SoundEffect monsterScreams;
    [SerializeField] private SoundEffect monsterSniff;

    private void Start()
    {
        stateMachine = GetComponent<SubjectBetaBehaviour>().StateMachine;
        stateMachine.ChangeStateEvent += PlayStateSound;
    }

    public void PlayMonsterScream()
    {
        monsterScreams.PlaySoundEffect();
    }

    public void PlayMonsterSniff()
    {
        monsterSniff.PlaySoundEffect();
    }

    private void PlayStateSound(State state)
    {
        if (state is AggroState)
        {
            
            AudioManager.Instance.PlayMusic("Section 1 Chase");
        }

        //else 
        //{
            //AudioManager.Instance.PlayMusic("Section 1 Horror");
        //}
    }
}
