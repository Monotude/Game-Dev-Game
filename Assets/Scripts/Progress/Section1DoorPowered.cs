using UnityEngine;

public class Section1DoorPowered : MonoBehaviour
{
    [SerializeField] private Animator leftDoor;
    [SerializeField] private Animator rightDoor;

    private void Start()
    {
        GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>().PowerOnEvent += OpenDoor;
    }

    private void OpenDoor()
    {

        AudioManager.Instance.PlaySFX("Door Open");
        leftDoor.Play("DoorOpenLeft");
        rightDoor.Play("DoorOpenRight");
    }
}
