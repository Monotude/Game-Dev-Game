using UnityEngine;

public class OpenSection2Door : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private KeypadInteract keypad;
    private Animator rightDoorAnimator;
    private Animator leftDoorAnimator;
    private ProgressManager progressManager;

    public bool IsDoorOpen { private get; set; }

    private void Awake()
    {
        rightDoorAnimator = rightDoor.GetComponent<Animator>();
        leftDoorAnimator = leftDoor.GetComponent<Animator>();
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        progressManager.LoadGameEvent += LoadDoor;
        keypad.KeypadSolvedEvent += OpenDoor;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !IsDoorOpen && !progressManager.Progress.GetIsSection2Cleared())
        {
            OpenDoor();
        }
    }

    private void LoadDoor()
    {
        if (progressManager.Progress.GetIsSection2Cleared())
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        IsDoorOpen = true;
        AudioManager.Instance.PlaySFX("Door Open");
        rightDoorAnimator.Play("DoorOpenRight");
        leftDoorAnimator.Play("DoorOpenLeft");
    }
}
