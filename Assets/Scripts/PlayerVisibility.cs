using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    private Light playerVisibilityLight;
    private PlayerFlashlight playerFlashlight;
    private PlayerUVLight playerUVLight;

    private void Start()
    {
        playerVisibilityLight = GetComponent<Light>();
        playerFlashlight = GameObject.Find("Flashlight Light").GetComponent<PlayerFlashlight>();
        playerUVLight = GameObject.Find("UV Light").GetComponent<PlayerUVLight>();
    }

    private void Update()
    {
        playerVisibilityLight.enabled = !playerFlashlight.IsFlashlightOn && !playerUVLight.IsUVLightOn;
    }
}
