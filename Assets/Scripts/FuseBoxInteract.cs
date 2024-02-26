using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private ObjectiveKeys objectiveKey;
    [SerializeField] private PowerOn powerTracker;
    [SerializeField] private GameObject fuse;
    [SerializeField] private int boxNumber;
    void Start()
    {
        fuse.SetActive(false);
    }

    public void Interact() {
        if(objectiveKey.GetObjectiveKey()) {
            fuse.SetActive(true);
            objectiveKey.SetObjectiveKey(false);
            powerTracker.UpdateFuses(boxNumber);
        }
    }

}
