using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private GameObject flashlightLight;
    private PlayerUVLight playerUVLight;
    private bool isFlashlightOn;

    public bool IsFlashlightOn { get => isFlashlightOn; }

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerUVLight = GetComponent<PlayerUVLight>();
    }

    private void Update()
    {
        isFlashlightOn = flashlightLight.activeInHierarchy;

        if (inputManager.FlashlightButtonDown && !playerUVLight.IsUVLightOn)
        {
            ChangeFlashlightState(!flashlightLight.activeInHierarchy);
        }
    }

    public void ChangeFlashlightState(bool state)
    {
        flashlightLight.SetActive(state);
        isFlashlightOn = state;
    }
}
