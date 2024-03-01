using UnityEngine;

public class ElectricalBoxInteract : MonoBehaviour, IInteractable
{
    private Animator animator;
    [SerializeField] private int electricalBoxNumber;

    public void Interact()
    {
        if (ObjectiveManager.Instance.Objective.TurnElectricalBoxOn(electricalBoxNumber))
        {
            animator.Play("LeverDown");
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
