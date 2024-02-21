using UnityEngine;

public class PlayerUVLight : MonoBehaviour
{
    private InputManager inputManager;
    private Light uVLight;
    private PlayerFlashlight playerFlashlight;
    private bool canUseUVLight;
    private bool isUVLightOn;
    private float currentUVLightSeconds;
    [SerializeField] private float uVLightSeconds;
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
    public int MaxCharges { get => this.maxCharges; set => this.maxCharges = value; }
    public float CurrentCharges { get; set; }

    private void RechargeUVLightCharges()
    {
        CurrentCharges = Mathf.Clamp(CurrentCharges + (Time.deltaTime * chargeRegenerationPerSecond), 0, MaxCharges);
    }

    private void Start()
    {
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        uVLight = GameObject.Find("UV Light").GetComponent<Light>();
        playerFlashlight = GameObject.Find("Flashlight Light").GetComponent<PlayerFlashlight>();
        currentUVLightSeconds = uVLightSeconds;
        CurrentCharges = MaxCharges;
    }

    private void Update()
    {
        canUseUVLight = playerFlashlight.IsFlashlightOn && CurrentCharges >= 1;

        if (canUseUVLight && inputManager.UVLightButtonDown)
        {
            playerFlashlight.IsFlashlightOn = false;
            IsUVLightOn = true;
        }

        if (IsUVLightOn)
        {
            currentUVLightSeconds -= Time.deltaTime;
            if (currentUVLightSeconds <= 0)
            {
                IsUVLightOn = false;
                playerFlashlight.IsFlashlightOn = true;
                CurrentCharges -= 1f;
                currentUVLightSeconds = uVLightSeconds;
            }
        }

        else
        {
            RechargeUVLightCharges();
        }
    }
}
