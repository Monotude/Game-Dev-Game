using UnityEngine;

public class PlayerUVLight : MonoBehaviour
{
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
        playerFlashlight = GameObject.FindWithTag("Flashlight").GetComponent<PlayerFlashlight>();
        uVLight = GameObject.FindWithTag("UV Light").GetComponent<Light>();
        remainingUVLightDuration = uVLightDuration;
        CurrentCharges = MaxCharges;
    }

    private void Update()
    {
        bool canUseUVLight = playerFlashlight.IsFlashlightOn && CurrentCharges >= 1;

        if (canUseUVLight && InputManager.Instance.UVLightButtonDown)
        {
            AudioManager.Instance.PlaySFX("UV LIGHT");
            playerFlashlight.IsFlashlightOn = false;
            IsUVLightOn = true;
        }

        if (IsUVLightOn)
        {
            remainingUVLightDuration -= Time.deltaTime;
            if (remainingUVLightDuration <= 0)
            {
                AudioManager.Instance.StopSFX();

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
