using UnityEngine;

public class CloseElevator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CloseDoors();
        }
    }

    private void CloseDoors()
    {
        animator.Play("ElevatorClose");
    }
}
