using UnityEngine;

public class PlayerCrouching : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 1.8f;
    [SerializeField] private float crouchSpeed = 2f;
    [SerializeField] private bool isCrouching = false;
    private PlayerSprint playerSprint;
    private PlayerMovement playerMovement;

    private float originalCameraPositionY;

    public bool IsCrouching => isCrouching;

    private void Start()
    {
        originalCameraPositionY = playerCamera.localPosition.y;
        playerSprint = GetComponent<PlayerSprint>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !playerSprint.IsSprinting) 
        {
            ToggleCrouch();
        }
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;

        if (isCrouching)
        {
            Crouch();
        }
        else
        {
            StandUp();
        }
    }
    
    private void Crouch()
    {
        playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, originalCameraPositionY - (standingHeight - crouchHeight), playerCamera.localPosition.z);
        transform.Translate(Vector3.down * crouchSpeed * Time.deltaTime);
        playerMovement.ResetMaximumSpeed();
    }

    private void StandUp()
    {
        playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, originalCameraPositionY, playerCamera.localPosition.z);
        playerMovement.ResetMaximumSpeed();

    }
}
