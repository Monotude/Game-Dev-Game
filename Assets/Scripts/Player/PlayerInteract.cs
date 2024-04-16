using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject interactPrompt;
    [Range(0.05f, 0.25f)]
    [SerializeField] private float interactAccuracy;
    [SerializeField] private float interactRange;
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        if (!Physics.SphereCast(ray, interactAccuracy, out RaycastHit hit, interactRange))
        {
            interactPrompt.SetActive(false);
            return;
        }

        if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactPrompt.SetActive(true);
        }

        else
        {
            interactPrompt.SetActive(false);
            return;
        }

        if(InputManager.Instance.InteractButtonDown)
        {
            interactable.Interact();
        }
    }
}
