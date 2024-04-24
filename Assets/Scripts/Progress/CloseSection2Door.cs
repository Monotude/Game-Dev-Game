using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private Animator rightDoorAnimator;
    private Animator leftDoorAnimator;
    private ProgressManager progressManager;
    private bool isPowerOff;

    private void Start()
    {
        rightDoorAnimator = rightDoor.GetComponent<Animator>();
        leftDoorAnimator = leftDoor.GetComponent<Animator>();
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPowerOff && !progressManager.Progress.GetIsSection2Cleared())
        {
            AudioManager.Instance.PlaySFX("Door Close");
            leftDoorAnimator.Play("DoorCloseLeft");
            rightDoorAnimator.Play("DoorCloseRight");
            isPowerOff = true;
            AudioManager.Instance.PlayMusic("Section 1 Horror");
        }
    }
}
