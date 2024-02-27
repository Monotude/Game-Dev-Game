using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerUVLight playerUVLight;
    private Light flashlightLight;
    private bool isFlashlightOn;

    public bool IsFlashlightOn
    {
        get => isFlashlightOn;

        set
        {
            flashlightLight.enabled = value;
            isFlashlightOn = value;
        }
    }

    private void Start()
    {
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        playerUVLight = GameObject.Find("UV Light").GetComponent<PlayerUVLight>();
        flashlightLight = GameObject.Find("Flashlight Light").GetComponent<Light>();
    }

    private void Update()
    {
        if (!playerUVLight.IsUVLightOn && inputManager.FlashlightButtonDown)
        {
            IsFlashlightOn = !flashlightLight.enabled;
        }
    }
}
