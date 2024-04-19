using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Slider mouseSensitivity;
    private PlayerRotation playerRotation;
    public Config Config { get; set; }

    public void FullscreenToggle()
    {
        Config.IsFullscreen = fullscreenToggle.isOn;
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void MouseSensitivityChange()
    {
        Config.MouseSensitivity = mouseSensitivity.value;
        if (playerRotation != null)
        {
            playerRotation.MouseSensitivity = mouseSensitivity.value;
        }
    }

    public void BackButton(GameObject menuToGoBackTo)
    {
        optionsMenu.SetActive(false);
        menuToGoBackTo.SetActive(true);
    }

    private void Start()
    {
        playerRotation = GameObject.FindWithTag("Player")?.GetComponent<PlayerRotation>();
        SaveManager.Instance.LoadConfig();
        fullscreenToggle.isOn = Config.IsFullscreen;
        mouseSensitivity.value = Config.MouseSensitivity;
        if (playerRotation != null)
        {
            playerRotation.MouseSensitivity = Config.MouseSensitivity;
        }
    }
}
