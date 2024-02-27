using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private GameObject player;
    [SerializeField] private float movementForce;
    [SerializeField] private float walkingSpeed;

    public float MaximumSpeed { get; set; }

    public void ResetMaximumSpeed()
    {
        MaximumSpeed = walkingSpeed;
    }

    private Vector3 GetForceVector()
    {
        Vector3 forceVector = new Vector3(InputManager.Instance.RightMovement, 0f, InputManager.Instance.ForwardMovement);
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

    private void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        MaximumSpeed = walkingSpeed;
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddRelativeForce(GetForceVector());
        LimitSpeed();
    }
}