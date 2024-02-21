using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMovement playerMovement;
    private PlayerCrouch playerCrouch;
    private bool isSprinting;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float maximumStamina;
    [SerializeField] private float staminaDecayPerSecond;
    [SerializeField] private float staminaRegenerationPerSecond;

    public bool IsSprinting
    {
        get => isSprinting;

        set
        {
            if (value)
            {
                playerMovement.MaximumSpeed = sprintSpeed;
            }

            else
            {
                playerMovement.ResetMaximumSpeed();
            }

            isSprinting = value;
        }
    }
    public float CurrentStamina { get; set; }
    public float MaximumStamina { get => maximumStamina; set => maximumStamina = value; }

    private void DecreaseStamina()
    {
        CurrentStamina -= Time.deltaTime * staminaDecayPerSecond;
    }

    private void IncreaseStamina()
    {
        CurrentStamina = Mathf.Clamp(CurrentStamina + (Time.deltaTime * staminaRegenerationPerSecond), 0, MaximumStamina);
    }

    private void Start()
    {
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCrouch = GetComponent<PlayerCrouch>();
        CurrentStamina = MaximumStamina;
    }

    private void Update()
    {
        bool canSprint = CurrentStamina > 0 && !playerCrouch.IsCrouching;
        if (canSprint && inputManager.SprintButtonDown)
        {
            IsSprinting = true;
        }

        if (IsSprinting)
        {
            DecreaseStamina();
            if (CurrentStamina <= 0 || inputManager.SprintButtonUp)
            {
                IsSprinting = false;
            }
        }

        else
        {
            IncreaseStamina();
        }
    }
}
