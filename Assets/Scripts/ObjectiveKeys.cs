using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveKeys : MonoBehaviour
{
    [SerializeField] private bool hasObjectiveKey;
    void Start()
    {
        hasObjectiveKey = false;
    }
    public bool GetObjectiveKey() {
        return hasObjectiveKey;
    }

    public void SetObjectiveKey(bool status) {
        hasObjectiveKey = status;
    }

}
