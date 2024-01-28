using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
