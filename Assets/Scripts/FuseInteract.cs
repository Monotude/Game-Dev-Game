using System;
using UnityEngine;

public class FuseInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    [SerializeField] private int fuseNumber;

    public event Action CollectFuseEvent;

    private void CollectFuse()
    {
        Destroy(gameObject);
    }

    public void Interact()
    {
        progressManager.Progress.CollectFuse(fuseNumber);
        CollectFuseEvent?.Invoke();
        CollectFuse();
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
        progressManager.LoadGame += LoadFuseProgress;
        CollectFuseEvent += progressManager.CheckSpawnMonster;
    }
}
