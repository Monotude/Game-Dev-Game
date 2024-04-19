using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Camera mainCamera;
    private float rotationX;
    private float rotationY;
    [SerializeField] private GameObject player;
    [SerializeField] private float lookAngle;
    public float MouseSensitivity { get; set; }

    private void CalculateRotation()
    {
        float horizontalMouseMovement = InputManager.Instance.HorizontalMouseMovement * Time.deltaTime * MouseSensitivity;
        float verticalMouseMovement = InputManager.Instance.VerticalMouseMovement * Time.deltaTime * MouseSensitivity;

        rotationY += horizontalMouseMovement;
        rotationX -= verticalMouseMovement;

        rotationY %= 360f;
        rotationX = Mathf.Clamp(rotationX, -lookAngle, lookAngle);
    }

    private void RotateCamera()
    {
        mainCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    private void RotatePlayer()
    {
        playerRigidbody.MoveRotation(Quaternion.Euler(0, rotationY, 0));
    }

    private void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CalculateRotation();
    }

    private void LateUpdate()
    {
        RotateCamera();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }
}
