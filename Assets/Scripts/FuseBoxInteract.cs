using UnityEngine;

public class FuseBoxInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    [SerializeField] private GameObject fuse;
    [SerializeField] private int fuseBoxNumber;

    private void PowerFuseBox()
    {
        fuse.SetActive(true);
    }

    public void Interact()
    {
        if (progressManager.Progress.PowerFuseBox(fuseBoxNumber))
        {
            PowerFuseBox();
        }
    }

    private void Start()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();

        if (progressManager.Progress.IsFuseBoxPowered(fuseBoxNumber))
        {
            PowerFuseBox();
        }
    }
}
