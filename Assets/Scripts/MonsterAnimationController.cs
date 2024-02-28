using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    private Animator animator;
    private MonsterStateMachine monsterStateMachine;

    private void Start()
    {
        animator = GetComponent<Animator>();
        monsterStateMachine = GetComponent<MonsterStateMachine>();
    }

    private void Update()
    {
        if (monsterStateMachine.CurrentMonsterState is PatrolState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", false);
        }

        else if (monsterStateMachine.CurrentMonsterState is IdleState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", true);
        }

        else if (monsterStateMachine.CurrentMonsterState is ChaseState)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isIdle", false);
        }
    }
}
