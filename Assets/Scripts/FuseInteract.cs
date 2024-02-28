using UnityEngine;

public class FuseInteract : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ++ObjectiveManager.Instance.FuseCollectedCount;
        Destroy(gameObject);
    }
}
