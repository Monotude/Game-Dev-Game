using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerUVLight playerUVLight;
    private bool isFlashlightOn;
    [SerializeField] private GameObject flashlightLight;

    public bool IsFlashlightOn
    {
        get => isFlashlightOn;

        set
        {
            flashlightLight.SetActive(value);
            isFlashlightOn = value;
        }
    }


    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerUVLight = GetComponent<PlayerUVLight>();
    }

    private void Update()
    {
        if (inputManager.FlashlightButtonDown && !playerUVLight.IsUVLightOn)
        {
            IsFlashlightOn = !flashlightLight.activeInHierarchy;
        }
    }
}
