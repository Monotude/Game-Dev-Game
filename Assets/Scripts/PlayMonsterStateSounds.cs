using UnityEngine;

public class PlayMonsterStateSounds : MonoBehaviour
{
    private MonsterStateMachine monsterStateMachine;
    private PlayMonsterScream monsterScream;

    private void Awake()
    {
        monsterStateMachine = GetComponent<MonsterStateMachine>();
        monsterScream = GetComponent<PlayMonsterScream>();
        monsterStateMachine.ChangeMonsterState += PlayStateSound;
    }

    private void PlayStateSound(MonsterState monsterState)
    {
        if (monsterState is ChaseState)
        {
            monsterScream.PlayScream();
            AudioManager.Instance.PlayMusic("Section 1 Chase");
        }

        else if (monsterState is FleeState)
        {
            AudioManager.Instance.PlayMusic("Section 1 Horror");
        }
    }
}
