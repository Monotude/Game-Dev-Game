using UnityEngine;

public class PlayerUVLight : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerFlashlight playerFlashlight;
    private Light uVLight;
    private bool isUVLightOn;
    private float remainingUVLightDuration;
    [SerializeField] private float uVLightDuration;
    [SerializeField] private int maxCharges;
    [SerializeField] private float chargeRegenerationPerSecond;

    public bool IsUVLightOn
    {
        get => isUVLightOn;

        set
        {
            uVLight.enabled = value;
            isUVLightOn = value;
        }
    }
    public float CurrentCharges { get; set; }
    public int MaxCharges { get => this.maxCharges; set => this.maxCharges = value; }

    private void RechargeUVLightCharges()
    {
        CurrentCharges = Mathf.Clamp(CurrentCharges + (Time.deltaTime * chargeRegenerationPerSecond), 0, MaxCharges);
    }

    private void Start()
    {
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        playerFlashlight = GameObject.Find("Flashlight Light").GetComponent<PlayerFlashlight>();
        uVLight = GameObject.Find("UV Light").GetComponent<Light>();
        remainingUVLightDuration = uVLightDuration;
        CurrentCharges = MaxCharges;
    }

    private void Update()
    {
        bool canUseUVLight = playerFlashlight.IsFlashlightOn && CurrentCharges >= 1;

        if (canUseUVLight && inputManager.UVLightButtonDown)
        {
            playerFlashlight.IsFlashlightOn = false;
            IsUVLightOn = true;
        }

        if (IsUVLightOn)
        {
            remainingUVLightDuration -= Time.deltaTime;
            if (remainingUVLightDuration <= 0)
            {
                IsUVLightOn = false;
                playerFlashlight.IsFlashlightOn = true;
                CurrentCharges -= 1f;
                remainingUVLightDuration = uVLightDuration;
            }
        }

        else
        {
            RechargeUVLightCharges();
        }
    }
}
