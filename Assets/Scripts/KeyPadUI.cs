using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class KeyPadUI : MonoBehaviour
{
    [SerializeField] private GameObject keyPad;
    [SerializeField] private string passcode;
    [SerializeField] private TextMeshPro keyPadText;
    [SerializeField] private TextMeshProUGUI keyPadTexUI;
    [SerializeField] private GameObject loreDoor;
    private string inputCode = "";
    private Animator loreDoorAnimator;


    public void InputCode0()
    {
        inputCode = inputCode + "0";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode1()
    {
        inputCode = inputCode + "1";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode2()
    {
        inputCode = inputCode + "2";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode3()
    {
        inputCode = inputCode + "3";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode4()
    {
        inputCode = inputCode + "4";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode5()
    {
        inputCode = inputCode + "5";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode6()
    {
        inputCode = inputCode + "6";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode7()
    {
        inputCode = inputCode + "7";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode8()
    {
        inputCode = inputCode + "8";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void InputCode9()
    {
        inputCode = inputCode + "9";
        keyPadText.text = inputCode;
        keyPadTexUI.text = inputCode;
    }

    public void ClearInputCode() {
        inputCode = "";
    }

    public void EnterInputCode() {
        if(inputCode.Equals(passcode)) {
            Debug.Log("Correct");
            keyPad.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            loreDoorAnimator.Play("DoorOpening");
            Destroy(loreDoor.GetComponent<Collider>());
        }
        else {
            ClearInputCode();
        }
    }

    private void Start()
    {
        keyPad.SetActive(false);
        loreDoorAnimator = loreDoor.GetComponent<Animator>();
    }

}
