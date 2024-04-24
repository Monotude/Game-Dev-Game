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
        AudioManager.Instance.PlaySFX("Keypad Push");
        if (keypadText.text.Length < 4)
        {
            keypadText.text = keypadText.text + number;
        }
    }

    public void ClearInputCode()
    {
        AudioManager.Instance.PlaySFX("Keypad Push");
        keypadText.text = "";
    }

    public void EnterInputCode()
    {
        AudioManager.Instance.PlaySFX("Keypad Push");
        if (keypadText.text.Equals(Passcode))
        {
            CorrectCodeEvent?.Invoke();
        }

        keypadUI.SetActive(false);
        ClearInputCode();
        PauseMenu.ResumeGame();
    }
}
