using UnityEngine;

public class CameraMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 standingOffset;
    [SerializeField] private Vector3 crouchingOffset;

    private PlayerCrouching crouchController;

    private void Start()
    {
        crouchController = player.GetComponent<PlayerCrouching>();
=======
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 standingOffset;
    [SerializeField] private Vector3 crouchingOffset;

    private PlayerCrouch crouchController;

    private void Start()
    {
        crouchController = player.GetComponent<PlayerCrouch>();
>>>>>>> Stashed changes
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 offset = crouchController.IsCrouching ? crouchingOffset : standingOffset;
<<<<<<< Updated upstream
        transform.position = player.position + offset;
=======
        transform.position = player.transform.position + offset;
>>>>>>> Stashed changes
    }
}
