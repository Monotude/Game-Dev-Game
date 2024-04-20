using UnityEngine;

public class SubjectBetaAnimations : MonoBehaviour
{
    private Animator animator;
    private StateMachine stateMachine;

    private void Start()
    {
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<SubjectBetaBehaviour>().StateMachine;
        stateMachine.ChangeStateEvent += AnimationChange;
    }

    private void AnimationChange(State state)
    {
        if (state is RoamState)
        {
            animator.SetBool("isInvestigating", false);
            animator.SetBool("isAggroed", false);
        }

        else if (state is InvestigateState)
        {
            animator.SetBool("isInvestigating", true);
            animator.SetBool("isAggroed", false);
        }

        else if (state is AggroState)
        {
            animator.SetBool("isInvestigating", false);
            animator.SetBool("isAggroed", true);
        }
    }
}
