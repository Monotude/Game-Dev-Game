using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float movementForce;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float crouchingSpeed;


    private PlayerCrouching playerCrouch;
    public float MaximumSpeed { get; set; }

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerCrouch = GetComponent<PlayerCrouching>();
        MaximumSpeed = walkingSpeed;
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddRelativeForce(GetForceVector());
        LimitSpeed();
    }

    public void ResetMaximumSpeed()
    {
        if (playerCrouch.IsCrouching) 
            MaximumSpeed = crouchingSpeed;
        else
            MaximumSpeed = walkingSpeed;
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

        if (flatMovementVector.magnitude > MaximumSpeed)
        {
            flatMovementVector = flatMovementVector.normalized * MaximumSpeed;
            playerRigidbody.velocity = new Vector3(flatMovementVector.x, playerRigidbody.velocity.y, flatMovementVector.z);
        }
    }
}
