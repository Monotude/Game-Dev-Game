using System;
using UnityEngine;

public class ElectricalBoxInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    private Animator animator;
    [SerializeField] private int electricalBoxNumber;

    public event Action ElectricalBoxOnEvent;

    private void ElectricalBoxOn()
    {
        animator.Play("LeverDown");
    }

    public void Interact()
    {
        if (progressManager.Progress.TurnElectricalBoxOn(electricalBoxNumber))
        {
            ElectricalBoxOnEvent?.Invoke();
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
        ElectricalBoxOnEvent += progressManager.CheckTurnLightsOn;
        animator = GetComponent<Animator>();
    }
}
