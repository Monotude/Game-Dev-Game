using System;
using UnityEngine;

public class KeypadInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string passcode;
    [SerializeField] private GameObject keypad;
    private KeypadUI keypadUI;

    public bool IsCodeEntered { get; set; }
    public Action KeypadSolvedEvent;

    public void Interact()
    {
        if (!IsCodeEntered)
        {
            keypadUI.Passcode = passcode;
            keypadUI.CorrectCodeEvent = KeypadSolvedEvent;
            keypad.SetActive(true);
            PauseMenu.PauseGame();
        }
    }

    public void KeypadSolved()
    {
        IsCodeEntered = true;
    }

    private void Awake()
    {
        keypadUI = GameObject.FindWithTag("UI Controller").GetComponent<KeypadUI>();
        KeypadSolvedEvent += KeypadSolved;
    }
}
