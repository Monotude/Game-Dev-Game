using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private InputManager inputManager;
    private Light flashlightLight;
    private PlayerUVLight playerUVLight;
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
        flashlightLight = GameObject.Find("Flashlight Light").GetComponent<Light>();
        playerUVLight = GameObject.Find("UV Light").GetComponent<PlayerUVLight>();
    }

    private void Update()
    {
        if (inputManager.FlashlightButtonDown && !playerUVLight.IsUVLightOn)
        {
            IsFlashlightOn = !flashlightLight.enabled;
        }
    }
}
