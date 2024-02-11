using UnityEngine;

public class PlayerUVLight : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerFlashlight playerFlashlight;
    private bool canUseUVLight;
    private bool isUVLightOn;
    private float currentUVLightSeconds;
    [SerializeField] private GameObject uVLight;
    [SerializeField] private float uVLightSeconds;

    public bool IsUVLightOn
    {
        get => isUVLightOn;

        set
        {
            uVLight.SetActive(value);
            isUVLightOn = value;
        }
    }

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerFlashlight = GetComponent<PlayerFlashlight>();
        currentUVLightSeconds = uVLightSeconds;
    }

    private void Update()
    {
        canUseUVLight = playerFlashlight.IsFlashlightOn && inputManager.UVLightButtonDown;

        if (canUseUVLight)
        {
            IsUVLightOn = true;
        }

        if (IsUVLightOn)
        {
            currentUVLightSeconds -= Time.deltaTime;
            if (currentUVLightSeconds <= 0)
            {
                IsUVLightOn = false;
                currentUVLightSeconds = uVLightSeconds;
            }
        }
    }
}
