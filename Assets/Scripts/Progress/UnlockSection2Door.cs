using UnityEngine;

public class UnlockSection2Door : MonoBehaviour
{
    [SerializeField] private KeypadInteract keypad;
    private Animator animator;
    private ProgressManager progressManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        progressManager.LoadGameEvent += LoadDoorProgress;
        keypad.KeypadSolvedEvent += OpenDoor;
        keypad.KeypadSolvedEvent += progressManager.ClearSection2;
    }

    private void OpenDoor()
    {
        progressManager.Progress.ClearSection2();
        animator.Play("DoorOpening");
    }

    private void LoadDoorProgress()
    {
        if (progressManager.Progress.GetIsSection2Cleared())
        {
            keypad.IsCodeEntered = true;
            animator.Play("DoorOpening");
        }
    }
}
