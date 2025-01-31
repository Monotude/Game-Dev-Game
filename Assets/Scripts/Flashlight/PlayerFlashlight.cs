using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
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
        playerUVLight = GameObject.FindWithTag("UV Light").GetComponent<PlayerUVLight>();
        flashlightLight = GameObject.FindWithTag("Flashlight").GetComponent<Light>();
        IsFlashlightOn = true;
    }

    private void Update()
    {
        if (!playerUVLight.IsUVLightOn && InputManager.Instance.FlashlightButtonDown)
        {
            AudioManager.Instance.PlaySFX("Flashlight Click");
            IsFlashlightOn = !flashlightLight.enabled;
        }
    }
}
