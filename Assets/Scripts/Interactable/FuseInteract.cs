using System;
using UnityEngine;

public class FuseInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    private PlayerInventoryUI playerInventoryUI;
    [SerializeField] private int fuseNumber;
    [SerializeField] private AudioClip pickupSound;
    private AudioSource audioSource;

    public event Action CollectFuseEvent;

    private void CollectFuse()
    {
        Destroy(gameObject);
    }

    public void Interact()
    {
        progressManager.Progress.CollectFuse(fuseNumber);
        CollectFuseEvent?.Invoke();
        PlaySound();
        CollectFuse();
    }

    private void PlaySound()
    {
        if (audioSource != null && pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound); 
        }
    }

    private void LoadFuseProgress()
    {
        if (progressManager.Progress.IsFuseCollected(fuseNumber))
        {
            CollectFuse();
        }
    }

    private void Awake()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        playerInventoryUI = GameObject.FindWithTag("UI Controller").GetComponent<PlayerInventoryUI>();
        audioSource = GetComponent<AudioSource>();

        progressManager.LoadGameEvent += LoadFuseProgress;
        CollectFuseEvent += progressManager.CheckSpawnMonster1;
        CollectFuseEvent += playerInventoryUI.UpdateFuseUI;
    }
}