 /*using UnityEngine;

internal interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform InteractorSource;
    [SerializeField] private float InteractRange;

    //[SerializeField] private ObjectiveKeys objectiveKeys;

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
} */
