using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private Animator rightDoorAnimator;
    private Animator leftDoorAnimator;

    private void Start()
    {
        rightDoorAnimator = rightDoor.GetComponent<Animator>();
        leftDoorAnimator = leftDoor.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rightDoorAnimator.Play("DoorOpenRight");
            leftDoorAnimator.Play("DoorOpenLeft");
        }
    }

}
