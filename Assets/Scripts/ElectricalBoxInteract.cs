using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalBoxInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private PowerOn powerTracker;
    [SerializeField] private int boxNumber;
    [SerializeField] private Animator animator;

    public void Interact() {
        if(boxNumber == 1 && powerTracker.getFuseOn(1)) {
            powerTracker.UpdateBoxOne();
            animator.Play("LeverDown");
        }
        else if(boxNumber == 2 && powerTracker.getFuseOn(2)) {
            powerTracker.UpdateBoxTwo();
            animator.Play("LeverDown");
        }
        else if(boxNumber == 3 && powerTracker.getFuseOn(3)){
            powerTracker.UpdateBoxThree();
            animator.Play("LeverDown");
        }
        else if(boxNumber == 4 && powerTracker.getFuseOn(4)){
            powerTracker.UpdateBoxFour();
            animator.Play("LeverDown");
        }
    }

}
