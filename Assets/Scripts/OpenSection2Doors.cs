using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSection2Doors : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private GameObject leftDoor;
    private Animator rightDoorAnimator;
    private Animator leftDoorAnimator;
    private Collider collider;
    void Start()
    {
        rightDoorAnimator = rightDoor.GetComponent<Animator>();
        leftDoorAnimator = leftDoor.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.CompareTag("Player"))
        {
            rightDoorAnimator.Play("DoorOpenRight");
            leftDoorAnimator.Play("DoorOpenLeft");
        }
    }

}
