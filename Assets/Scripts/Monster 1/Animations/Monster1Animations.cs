using UnityEngine;

public class Monster1Animations : MonoBehaviour
{
    private Animator animator;
    private StateMachine stateMachine;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<Monster1Behaviour>().StateMachine;
        stateMachine.ChangeStateEvent += AnimationChange;
    }

    private void AnimationChange(State state)
    {
        if (state is ChaseState)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isFleeing", false);
        }

        else if (state is FleeState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isFleeing", true);
        }

        else if (state is PatrolState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isFleeing", false);
        }

        else if (state is IdleState)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isIdle", true);
            animator.SetBool("isFleeing", false);
        }
    }
}
