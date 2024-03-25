using UnityEngine;

public class PlayMonsterStateSounds : MonoBehaviour
{
    private MonsterStateMachine monsterStateMachine;
    private MonsterScream monsterScream;
    
            

    private void Awake()
    {
        monsterStateMachine = GetComponent<MonsterStateMachine>();
        monsterScream = GameObject.FindObjectOfType(typeof(MonsterScream)) as MonsterScream;

        monsterStateMachine.ChangeMonsterState += PlayStateSound;
    }

    private void PlayStateSound(MonsterState monsterState)
    {
        if (monsterState is ChaseState)
        {
            monsterScream.PlayMonsterScream();
            AudioManager.Instance.PlayMusic("Section 1 Chase");
        }

        else if (monsterState is FleeState)
        {
            AudioManager.Instance.PlayMusic("Section 1 Horror");
        }
    }
}
