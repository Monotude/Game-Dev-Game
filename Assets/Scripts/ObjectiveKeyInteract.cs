using UnityEngine;

public class ObjectiveKeyInteract : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    [SerializeField] private ObjectiveKeys objectiveKey;
    public void Interact()
    {
        if (!objectiveKey.GetObjectiveKey())
        {
            objectiveKey.SetObjectiveKey(true);
            Destroy(gameObject);
        }
    }

}
