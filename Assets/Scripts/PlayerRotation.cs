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

    private void LateUpdate()
    {
        CalculateRotation();
        RotateCamera();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }

    private void CalculateRotation()
    {
        float horizontalMouseMovement = inputManager.HorizontalMouseMovement * Time.deltaTime * mouseSensitivity;
        float verticalMouseMovement = inputManager.VerticalMouseMovement * Time.deltaTime * mouseSensitivity;

        rotationY += horizontalMouseMovement;
        rotationX -= verticalMouseMovement;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
    }

    private void RotateCamera()
    {
        mainCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    private void RotatePlayer()
    {
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
