using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float movementForce;
    [SerializeField] private float walkingSpeed;
    private float maximumSpeed;

    public float MaximumSpeed { get => maximumSpeed; set => maximumSpeed = value; }

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        maximumSpeed = walkingSpeed;
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddRelativeForce(GetForceVector());
        LimitSpeed();
    }

    public void ResetMaximumSpeed()
    {
        maximumSpeed = walkingSpeed;
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
}
