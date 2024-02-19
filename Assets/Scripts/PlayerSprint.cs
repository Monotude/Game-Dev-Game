using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMovement playerMovement;
    private PlayerCrouching playerCrouch;
    private bool canSprint;
    private bool isSprinting;
    [SerializeField] private float maximumSprintSeconds;
    [SerializeField] private float regenerationRatePerSecond;
    [SerializeField] private float sprintSpeed;

    public bool IsSprinting
    {
        get => isSprinting;

        set
        {
            if (value)
            {
                playerMovement.MaximumSpeed = sprintSpeed;
                isSprinting = true;
            }

            else
            {
                playerMovement.ResetMaximumSpeed();
                isSprinting = false;
            }
        }
    }
    public float RemainingSprintSeconds { get; set; }
    public float MaximumSprintSeconds { get => maximumSprintSeconds; set => maximumSprintSeconds = value; }

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCrouch = GetComponent<PlayerCrouching>();
        RemainingSprintSeconds = maximumSprintSeconds;
    }

    private void Update()
    {
        canSprint = RemainingSprintSeconds > 0; //check for crouching when we add crouching;
        if (canSprint && inputManager.SprintButtonDown && !playerCrouch.IsCrouching)
        {
            IsSprinting = true;
        }

        if (IsSprinting)
        {
            DecreaseStamina();
            if (RemainingSprintSeconds <= 0 || inputManager.SprintButtonUp)
            {
                IsSprinting = false;
            }
        }

        else
        {
            IncreaseStamina();
        }
    }

    private void DecreaseStamina()
    {
        RemainingSprintSeconds -= Time.deltaTime;
    }

    private void IncreaseStamina()
    {
        RemainingSprintSeconds = Mathf.Clamp(RemainingSprintSeconds + (Time.deltaTime * regenerationRatePerSecond), 0, maximumSprintSeconds);
    }
}
