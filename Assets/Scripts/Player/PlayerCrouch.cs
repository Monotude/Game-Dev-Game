using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
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
                playerMovement.MaximumSpeed = crouchSpeed;
            }

            else
            {
                playerMovement.ResetMaximumSpeed();
            }

            isCrouching = value;

        }
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSprint = GetComponent<PlayerSprint>();
    }

    private void Update()
    {
        bool canCrouch = !playerSprint.IsSprinting;
        if (canCrouch)
        {
            if (InputManager.Instance.CrouchButtonDown)
            {
                IsCrouching = true;
            }

            else if (InputManager.Instance.CrouchButtonUp)
            {
                IsCrouching = false;
            }
        }
    }
}
