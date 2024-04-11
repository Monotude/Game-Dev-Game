using UnityEngine;

public class PlayerUVLight : MonoBehaviour
{
    private PlayerFlashlight playerFlashlight;
    private Light uVLight;
    private bool isFlashlightOn;
    private bool isUVLightOn;
    private float currentTimeHeld;
    [SerializeField] private float uVLightBufferSeconds; // UV Light Charges will not increase until this seconds
    [SerializeField] private float uVLightMaxCharge;
    [SerializeField] private float chargeRegenerationPerSecond;
    [SerializeField] private float chargeDecayPerSecond;

    public bool IsUVLightOn
    {
        get => isUVLightOn;

        set
        {
            uVLight.enabled = value;
            isUVLightOn = value;
        }
    }
    public float CurrentCharges { get; private set; }
    public float MaxCharges => this.uVLightMaxCharge;

    private void DecreaseCharges()
    {
        CurrentCharges -= Time.deltaTime * chargeDecayPerSecond;
    }

    private void DisableUVLight()
    {
        IsUVLightOn = false;
        playerFlashlight.IsFlashlightOn = isFlashlightOn;
        AudioManager.Instance.StopSFX();
    }

    private void EnableUVLight()
    {
        currentTimeHeld = 0f;
        isFlashlightOn = playerFlashlight.IsFlashlightOn;
        playerFlashlight.IsFlashlightOn = false;
        IsUVLightOn = true;
        AudioManager.Instance.PlaySFX("UV Light");
    }

    private void IncreaseUVLightCharges()
    {
        CurrentCharges = Mathf.Clamp(CurrentCharges + (Time.deltaTime * chargeRegenerationPerSecond), 0f, MaxCharges);
    }

    private void Start()
    {
        playerFlashlight = GameObject.FindWithTag("Flashlight").GetComponent<PlayerFlashlight>();
        uVLight = GameObject.FindWithTag("UV Light").GetComponent<Light>();
        AudioManager.Instance.StopSFX();
    }

    private void Update()
    {
        if (IsUVLightOn)
        {
            DecreaseCharges();
            if (CurrentCharges <= 0f)
            {
                DisableUVLight();
            }
        }

        else if (currentTimeHeld >= uVLightBufferSeconds && (CurrentCharges == MaxCharges || !InputManager.Instance.UVLightButton))
        {
            EnableUVLight();
        }

        else if (InputManager.Instance.UVLightButton)
        {
            if (currentTimeHeld <= uVLightBufferSeconds)
            {
                currentTimeHeld += Time.deltaTime;
            }

            else
            {
                IncreaseUVLightCharges();
            }
        }

        else
        {
            currentTimeHeld = 0;
        }
    }
}
