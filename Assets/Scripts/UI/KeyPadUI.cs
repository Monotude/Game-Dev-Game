using System;
using TMPro;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    [SerializeField] private GameObject keypadUI;
    [SerializeField] private TextMeshProUGUI keypadText;
    [SerializeField] private SoundEffect buttonSfx;

    public string Passcode { get; set; }
    public Action CorrectCodeEvent;

    public void InputButton(int number)
    {
        buttonSfx.PlaySoundEffect();
        if (keypadText.text.Length < 4)
        {
            keypadText.text = keypadText.text + number;
        }
    }

    public void ClearInputCode()
    {
        buttonSfx.PlaySoundEffect();
        keypadText.text = "";
    }

    public void EnterInputCode()
    {
        buttonSfx.PlaySoundEffect();
        if (keypadText.text.Equals(Passcode))
        {
            CorrectCodeEvent?.Invoke();
        }

        keypadUI.SetActive(false);
        ClearInputCode();
        PauseMenu.ResumeGame();
    }
}
