using UnityEngine;

public class FuseInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private int fuseNumber;

    public void Interact()
    {
        ObjectiveManager.Instance.Objective.CollectFuse(fuseNumber);
        Destroy(gameObject);
    }
}
