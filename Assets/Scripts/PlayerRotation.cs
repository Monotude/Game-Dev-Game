using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private InputManager inputManager;
    private Camera mainCamera;
    private float rotationX;
    private float rotationY;
    [SerializeField] private float mouseSensitivity;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float horizontalMouseMovement = inputManager.HorizontalMouseMovement * Time.deltaTime * mouseSensitivity;
        float verticalMouseMovement = inputManager.VerticalMouseMovement * Time.deltaTime * mouseSensitivity;

        rotationY += horizontalMouseMovement;
        rotationX -= verticalMouseMovement;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        mainCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
