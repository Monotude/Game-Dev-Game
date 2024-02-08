using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Included in this script is implementation for movement, sprinting, and stamina system + UI

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float defaultMovementForce = 1000f;
    [SerializeField] private float defaultMaximumSpeed = 4f;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaConsumptionRate = 50f;
    [SerializeField] private float staminaRegenerationRate = 5f;

    private float movementForce;
    private float maximumSpeed;
    private float currentStamina;
    public bool running;

    public Image StaminaBar;
    public Image Background;
    private bool isStaminaBarFading = false;

    public float MaximumSpeed { get => maximumSpeed; set => maximumSpeed = value; }

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        movementForce = defaultMovementForce;
        maximumSpeed = defaultMaximumSpeed;
        currentStamina = maxStamina;
        running = false;
    }

    private void Update()
    {
        if (inputManager.StartSprint) 
            running = true;
        else if (inputManager.StopSprint)
            running = false;
    }

    private void FixedUpdate()
    {
        if (running && currentStamina > 0)
        {
            Sprint();
        }
        else {
            RegenerateStamina();
            playerRigidbody.AddRelativeForce(GetForceVector());
            LimitSpeed();
        }

    }

    private void Sprint() 
    {
        playerRigidbody.AddRelativeForce(GetForceVector() * sprintMultiplier);
        StartCoroutine(FadeInStaminaBar());
        ConsumeStamina();
        if (currentStamina < 0)
            running = false;
        LimitSpeed();
    }

    private Vector3 GetForceVector()
    {
        Vector3 forceVector = new Vector3(inputManager.RightMovement, 0f, inputManager.ForwardMovement);
        forceVector = forceVector.normalized * movementForce;
        return forceVector;
    }

    private void LimitSpeed()
    {
        Vector3 flatMovementVector = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        if (flatMovementVector.magnitude > maximumSpeed)
        {
            flatMovementVector = flatMovementVector.normalized * maximumSpeed;
            playerRigidbody.velocity = new Vector3(flatMovementVector.x, playerRigidbody.velocity.y, flatMovementVector.z);
        }
    }

    private void ConsumeStamina()
    {
        Debug.Log(currentStamina);
        currentStamina = Mathf.Max(-1f, currentStamina - staminaConsumptionRate * Time.fixedDeltaTime);

        StaminaBar.fillAmount = currentStamina / maxStamina;
    }

    private void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenerationRate * Time.fixedDeltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

            StaminaBar.fillAmount = currentStamina / maxStamina;
        }
        else
        {
            StartCoroutine(FadeOutStaminaBar());
        }
    }

        private IEnumerator FadeOutStaminaBar()
    {
        if (!isStaminaBarFading)
        {
            isStaminaBarFading = true;

            while (StaminaBar.color.a > 0)
            {
                Color newColor = StaminaBar.color;
                newColor.a -= Time.deltaTime;
                StaminaBar.color = newColor;

                Color tempColor = Background.color;
                tempColor.a -= Time.deltaTime;
                Background.color = tempColor;

                yield return null;
            }

            isStaminaBarFading = false;
        }
    }

    private IEnumerator FadeInStaminaBar()
    {
        if (!isStaminaBarFading)
        {
            isStaminaBarFading = true;

            while (StaminaBar.color.a < 1)
            {
                Color newColor = StaminaBar.color;
                newColor.a += Time.deltaTime * 2;
                StaminaBar.color = newColor;

                Color tempColor = Background.color;
                tempColor.a += Time.deltaTime * 2;
                Background.color = tempColor;

                yield return null;
            }

            isStaminaBarFading = false;
        }
    }
}


