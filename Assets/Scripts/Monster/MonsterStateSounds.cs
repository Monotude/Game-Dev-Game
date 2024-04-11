using UnityEngine;

public class MonsterStateSounds : MonoBehaviour
{
    private MonsterStateMachine monsterStateMachine;
    private MonsterScream monsterScream;

    private void Awake()
    {
        monsterStateMachine = GetComponent<MonsterStateMachine>();
        monsterScream = GetComponent<MonsterScream>();
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
