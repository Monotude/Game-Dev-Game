using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private Animator rightDoorAnimator;
    private Animator leftDoorAnimator;
    private bool isPowerOff;

    private void Start()
    {
        rightDoorAnimator = rightDoor.GetComponent<Animator>();
        leftDoorAnimator = leftDoor.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPowerOff)
        {
            leftDoorAnimator.Play("DoorCloseLeft");
            rightDoorAnimator.Play("DoorCloseRight");
            isPowerOff = true;
        }
    }
}
