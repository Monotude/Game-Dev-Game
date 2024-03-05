using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerCrouch playerCrouch;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 standingOffset;
    [SerializeField] private Vector3 crouchingOffset;
    [SerializeField] private float standingUpdateSpeed;
    [SerializeField] private float crouchingUpdateSpeed;

    private void MoveCamera()
    {
        Vector3 offset = playerCrouch.IsCrouching ? crouchingOffset : standingOffset;
        float updateSpeed = playerCrouch.IsCrouching ? crouchingUpdateSpeed : standingUpdateSpeed;
        transform.position = Vector3.MoveTowards(transform.position, player.position + offset, updateSpeed * Time.deltaTime);
    }

    private void Awake()
    {
        playerCrouch = player.GetComponent<PlayerCrouch>();
    }

    private void LateUpdate()
    {
        MoveCamera();
    }
}
