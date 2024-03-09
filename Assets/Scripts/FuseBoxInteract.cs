using UnityEngine;

public class FuseBoxInteract : MonoBehaviour, IInteractable
{
    private ProgressManager progressManager;
    [SerializeField] private GameObject fuse;
    [SerializeField] private int fuseBoxNumber;
    [SerializeField] private GameObject wire;

    private void PowerFuseBox()
    {
        fuse.SetActive(true);
        wire.GetComponent<Renderer>().material.color = Color.green;
    }

    public void Interact()
    {
        if (progressManager.Progress.PowerFuseBox(fuseBoxNumber))
        {
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
        progressManager.LoadGame += LoadFuseBoxProgress;
    }
}
