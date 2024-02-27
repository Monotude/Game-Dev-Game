/*using UnityEngine;

public class ElectricalBoxInteract : MonoBehaviour, IInteractable
{
    // [SerializeField] private PowerOn powerTracker;
    [SerializeField] private ObjectiveKeys objectiveKey;
    [SerializeField] private int boxNumber;
    [SerializeField] private Animator animator;

    public void Interact()
    {
        if (boxNumber == 1 && objectiveKey.GetObjectiveKey())
        {
            //powerTracker.UpdateBoxOne();
            animator.Play("LeverDown");
            objectiveKey.SetObjectiveKey(false);
        }
        else if (boxNumber == 2 && objectiveKey.GetObjectiveKey())
        {
            //powerTracker.UpdateBoxTwo();
            animator.Play("LeverDown");
            objectiveKey.SetObjectiveKey(false);
        }
        else if (boxNumber == 3 && objectiveKey.GetObjectiveKey())
        {
            //powerTracker.UpdateBoxThree();
            animator.Play("LeverDown");
            objectiveKey.SetObjectiveKey(false);
        }
    }

}
*/