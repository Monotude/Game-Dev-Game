using UnityEngine;

public class ElectricalBoxInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    private Animator animator;
    [SerializeField] private int electricalBoxNumber;

    private void ElectricalBoxOn()
    {
        animator.Play("LeverDown");
    }

    public void Interact()
    {
        if (progressManager.Progress.TurnElectricalBoxOn(electricalBoxNumber))
        {
            ElectricalBoxOn();
        }
    }

    private void Start()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        animator = GetComponent<Animator>();

        if (progressManager.Progress.IsElectricalBoxOn(electricalBoxNumber))
        {
            ElectricalBoxOn();
        }
    }
}
