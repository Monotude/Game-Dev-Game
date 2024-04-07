using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Transform mainCamera;
    [Range(0.05f, 0.25f)]
    [SerializeField] private float interactAccuracy;
    [SerializeField] private float interactRange;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (!InputManager.Instance.InteractButtonDown)
        {
            return;
        }

        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        if (!Physics.SphereCast(ray, interactAccuracy, out RaycastHit hit, interactRange))
        {
            return;
        }

        if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }
}
