using UnityEngine;

public class PlayerUVLight : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerFlashlight playerFlashlight;
    [SerializeField] private GameObject uVLight;
    private bool canUseUVLight;
    private bool isUVLightOn;
    private float currentUVLightSeconds;
    [SerializeField] private float uVLightSeconds;

    public bool IsUVLightOn { get => isUVLightOn; set => isUVLightOn = value; }

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
            playerFlashlight.ChangeFlashlightState(false);
            ChangeUVLightState(true);
        }

        if (isUVLightOn)
        {
            currentUVLightSeconds -= Time.deltaTime;
            if (currentUVLightSeconds <= 0)
            {
                ChangeUVLightState(false);
                playerFlashlight.ChangeFlashlightState(true);
                currentUVLightSeconds = uVLightSeconds;
            }
        }
    }

    private void ChangeUVLightState(bool state)
    {
        uVLight.SetActive(state);
        isUVLightOn = state;
    }
}
