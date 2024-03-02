using UnityEngine;

public class FuseInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    [SerializeField] private int fuseNumber;

    private void CollectFuse()
    {
        Destroy(gameObject);
    }

    public void Interact()
    {
        progressManager.Progress.CollectFuse(fuseNumber);
        CollectFuse();
    }

    private void Start()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();

        if (progressManager.Progress.IsFuseCollected(fuseNumber))
        {
            CollectFuse();
        }
    }
}
