using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 standingOffset;
    [SerializeField] private Vector3 crouchingOffset;

    private PlayerCrouching crouchController;

    private void Start()
    {
        crouchController = player.GetComponent<PlayerCrouching>();
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 offset = crouchController.IsCrouching ? crouchingOffset : standingOffset;
        transform.position = player.position + offset;
    }
}
