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

    private void LoadElectricalBoxProgress()
    {
        if (progressManager.Progress.IsElectricalBoxOn(electricalBoxNumber))
        {
            ElectricalBoxOn();
        }
    }

    private void Awake()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        progressManager.LoadGame += LoadElectricalBoxProgress;
        animator = GetComponent<Animator>();
    }
}
