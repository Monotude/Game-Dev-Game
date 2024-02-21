using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMovement playerMovement;
    private PlayerSprint playerSprint;
    private bool isCrouching;
    [SerializeField] private float crouchSpeed;

    public bool IsCrouching
    {
        get => isCrouching;

        set
        {
            if (value)
            {
                Crouch();
            }

            else
            {
                StandUp();
            }

            isCrouching = value;

        }
    }

    private void Crouch()
    {
        playerMovement.MaximumSpeed = crouchSpeed;
    }

    private void StandUp()
    {
        playerMovement.ResetMaximumSpeed();
    }

    private void Start()
    {
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerSprint = GetComponent<PlayerSprint>();
    }

    private void Update()
    {
        bool canCrouch = !playerSprint.IsSprinting;
        if (canCrouch)
        {
            if (inputManager.CrouchButtonDown)
            {
                IsCrouching = true;
            }

            else if (inputManager.CrouchButtonUp)
            {
                IsCrouching = false;
            }
        }
    }
}
