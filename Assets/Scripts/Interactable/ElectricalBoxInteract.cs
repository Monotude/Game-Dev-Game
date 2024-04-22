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
        AudioManager.Instance.PlaySFX("Lever Pull");
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
        progressManager.LoadGameEvent += LoadElectricalBoxProgress;
        ElectricalBoxOnEvent += progressManager.CheckClearSection1;
        animator = GetComponent<Animator>();
    }
}
