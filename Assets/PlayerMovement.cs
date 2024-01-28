using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody rb;
    private float force = 12.5f;
    private float speed =5f;

    void FixedUpdate()
    {
        Vector3 directionVector = new Vector3(inputManager.HorizontalKeys, rb.velocity.y, inputManager.VerticalKeys);
        directionVector = directionVector.normalized;
        directionVector = directionVector * force;
        rb.AddForce(directionVector);
        if(rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized;
            rb.velocity *= speed;
        }
    }
}
