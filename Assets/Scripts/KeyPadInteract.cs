using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject KeyPad;
    private bool isCodeEntered;
    void Start()
    {
        isCodeEntered = false;
    }

    public void Interact()
    {
        if(!isCodeEntered) {
            KeyPad.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isCodeEntered = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
