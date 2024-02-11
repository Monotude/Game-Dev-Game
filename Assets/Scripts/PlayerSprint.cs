using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMovement playerMovement;
    private bool canSprint;
    private bool isSprinting;
    private float remainingSprintSeconds;
    [SerializeField] private float maximumSprintSeconds;
    [SerializeField] private float regenerationRatePerSecond;
    [SerializeField] private float sprintSpeed;

    public bool IsSprinting { get => isSprinting; set => isSprinting = value; }
    public float RemainingSprintSeconds { get => remainingSprintSeconds; set => remainingSprintSeconds = value; }
    public float MaximumSprintSeconds { get => maximumSprintSeconds; set => maximumSprintSeconds = value; }

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        remainingSprintSeconds = maximumSprintSeconds;
    }

    private void Update()
    {
        canSprint = remainingSprintSeconds > 0; //check for crouching when we add crouching;
        if (canSprint && inputManager.SprintButtonDown)
        {
            isSprinting = true;
        }

        if (isSprinting)
        {
            DecreaseStamina();
            Sprint();
            if (remainingSprintSeconds <= 0 || inputManager.SprintButtonUp)
            {
                isSprinting = false;
            }
        }

        else
        {
            IncreaseStamina();
            StopSprinting();
        }
    }

    private void Sprint()
    {
        playerMovement.MaximumSpeed = sprintSpeed;
    }

    private void DecreaseStamina()
    {
        remainingSprintSeconds -= Time.deltaTime;
    }

    private void StopSprinting()
    {
        if (playerMovement.MaximumSpeed == sprintSpeed)
        {
            playerMovement.ResetMaximumSpeed();
        }
    }

    private void IncreaseStamina()
    {
        remainingSprintSeconds = Mathf.Clamp(remainingSprintSeconds + Time.deltaTime * regenerationRatePerSecond, 0, maximumSprintSeconds);
    }
}
