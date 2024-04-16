using System;
using UnityEngine;

public class FuseBoxInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    private PlayerInventoryUI playerInventoryUI;
    [SerializeField] private GameObject fuse;
    [SerializeField] private int fuseBoxNumber;
    [SerializeField] private GameObject wire;

    public Action PowerFuseBoxEvent;

    private void PowerFuseBox()
    {
        fuse.SetActive(true);
        wire.GetComponent<Renderer>().material.color = Color.green;
    }

    public void Interact()
    {
        if (progressManager.Progress.PowerFuseBox(fuseBoxNumber))
        {
            PowerFuseBoxEvent?.Invoke();
            PowerFuseBox();
        }
    }

    private void LoadFuseBoxProgress()
    {
        if (progressManager.Progress.IsFuseBoxPowered(fuseBoxNumber))
        {
            PowerFuseBox();
        }
    }

    private void Awake()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        playerInventoryUI = GameObject.FindWithTag("UI Controller").GetComponent<PlayerInventoryUI>();
        progressManager.LoadGameEvent += LoadFuseBoxProgress;
        PowerFuseBoxEvent += playerInventoryUI.UpdateFuseUI;
    }
}
