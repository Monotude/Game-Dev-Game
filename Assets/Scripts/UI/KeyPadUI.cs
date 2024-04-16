using System;
using TMPro;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    [SerializeField] private GameObject keypadUI;
    [SerializeField] private TextMeshProUGUI keypadText;

    public string Passcode { get; set; }
    public Action CorrectCodeEvent;

    public void InputButton(int number)
    {
        if (keypadText.text.Length < 4)
        {
            keypadText.text = keypadText.text + number;
        }
    }

    public void ClearInputCode()
    {
        keypadText.text = "";
    }

    public void EnterInputCode()
    {
        if (keypadText.text.Equals(Passcode))
        {
            CorrectCodeEvent?.Invoke();
        }

        else
        {
            ClearInputCode();
        }

        PauseMenu.ResumeGame();
        keypadUI.SetActive(false);
    }
}
