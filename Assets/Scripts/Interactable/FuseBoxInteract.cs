using System;
using UnityEngine;

public class FuseBoxInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    private PlayerInventoryUI playerInventoryUI;
    [SerializeField] private GameObject fuse;
    [SerializeField] private int fuseBoxNumber;
    [SerializeField] private GameObject wire;
    [SerializeField] private AudioClip sound;
    private AudioSource audioSource;

    public Action PowerFuseBoxEvent;

    private void PowerFuseBox()
    {
        PlaySound();
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

    private void PlaySound()
    {
        if (audioSource != null && sound != null)
        {
            audioSource.PlayOneShot(sound); 
        }
    }

    private void Awake()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        playerInventoryUI = GameObject.FindWithTag("UI Controller").GetComponent<PlayerInventoryUI>();
        audioSource = GetComponent<AudioSource>();

        progressManager.LoadGameEvent += LoadFuseBoxProgress;
        PowerFuseBoxEvent += playerInventoryUI.UpdateFuseUI;
    }
}
