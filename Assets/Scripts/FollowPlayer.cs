using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    public Vector3 Offset { get => offset; set => offset = value; }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = player.position + offset;
    }
}
