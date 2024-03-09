using UnityEngine;

public class PlayMonsterStateSounds : MonoBehaviour
{
    private MonsterStateMachine monsterStateMachine;

    private void Awake()
    {
        monsterStateMachine = GetComponent<MonsterStateMachine>();
        monsterStateMachine.ChangeMonsterState += PlayStateSound;
    }

    private void PlayStateSound(MonsterState monsterState)
    {
        if (monsterState is ChaseState)
        {
            AudioManager.Instance.PlaySFX("Monster Scream");
            AudioManager.Instance.PlayMusic("Section 1 Chase");
        }

        else if (monsterState is FleeState)
        {
            AudioManager.Instance.PlayMusic("Section 1 Horror");
        }
    }
}
