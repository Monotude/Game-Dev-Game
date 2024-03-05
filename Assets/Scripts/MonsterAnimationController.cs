using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    private Animator animator;
    private MonsterStateMachine monsterStateMachine;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monsterStateMachine = GetComponent<MonsterStateMachine>();
    }

    private void Start()
    {
        monsterStateMachine.ChangeMonsterState += AnimationChange;
    }

    private void AnimationChange(MonsterState monsterState)
    {
        if (monsterStateMachine.CurrentMonsterState is ChaseState)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isFleeing", false);
        }

        else if (monsterStateMachine.CurrentMonsterState is FleeState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isFleeing", true);
        }

        else if (monsterStateMachine.CurrentMonsterState is PatrolState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isFleeing", false);
        }

        else if (monsterStateMachine.CurrentMonsterState is IdleState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", true);
            animator.SetBool("isFleeing", false);
        }
    }
}
