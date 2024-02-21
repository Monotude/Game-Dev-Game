using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerCrouch playerCrouch;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 standingOffset;
    [SerializeField] private Vector3 crouchingOffset;

    private void Move()
    {
        Vector3 offset = playerCrouch.IsCrouching ? crouchingOffset : standingOffset;
        transform.position = player.transform.position + offset;
    }

    private void Start()
    {
        playerCrouch = player.GetComponent<PlayerCrouch>();
    }

    private void LateUpdate()
    {
        Move();
    }
}
