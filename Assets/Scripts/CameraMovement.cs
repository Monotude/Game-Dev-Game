using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerCrouch playerCrouch;
    [SerializeField] private Transform player;
    [SerializeField] private float updateSpeed;
    [SerializeField] private Vector3 standingOffset;
    [SerializeField] private Vector3 crouchingOffset;

    private void MoveCamera()
    {
        Vector3 offset = playerCrouch.IsCrouching ? crouchingOffset : standingOffset;
        transform.position = Vector3.MoveTowards(transform.position, player.position + offset, updateSpeed * Time.deltaTime);
    }

    private void Start()
    {
        playerCrouch = player.GetComponent<PlayerCrouch>();
    }

    private void LateUpdate()
    {
        MoveCamera();
    }
}
