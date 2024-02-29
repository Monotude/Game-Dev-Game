using UnityEngine;

public class ElectricalBoxInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private int electricalBoxNumber;
    [SerializeField] private Animator animator;

    private bool IsElectricalBoxOn()
    {
        return ObjectiveManager.Instance.IsElectricalBoxOn[electricalBoxNumber];
    }

    private bool IsAssociatedFuseBoxPowered()
    {
        return ObjectiveManager.Instance.IsFuseBoxPowered[electricalBoxNumber];
    }

    public void Interact()
    {
        if (!IsElectricalBoxOn() && IsAssociatedFuseBoxPowered())
        {
            animator.Play("LeverDown");
            ObjectiveManager.Instance.IsElectricalBoxOn[electricalBoxNumber] = true;
        }
    }
}
