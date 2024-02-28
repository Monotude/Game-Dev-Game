using UnityEngine;

public class FuseBoxInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject fuse;
    [SerializeField] private int fuseBoxNumber;

    private bool IsFuseBoxPowered()
    {
        return ObjectiveManager.Instance.IsFuseBoxPowered[fuseBoxNumber];
    }

    public void Interact()
    {
        if (!IsFuseBoxPowered() && ObjectiveManager.Instance.FuseCollectedCount > 0)
        {
            --ObjectiveManager.Instance.FuseCollectedCount;
            ObjectiveManager.Instance.IsFuseBoxPowered[fuseBoxNumber] = true;
            fuse.SetActive(true);
        }
    }
}
