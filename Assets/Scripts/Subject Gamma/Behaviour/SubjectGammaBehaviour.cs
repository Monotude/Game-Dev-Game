using UnityEngine;

public class SubjectGammaBehaviour : MonoBehaviour
{
    [SerializeField] private float angerThreshold;
    [SerializeField] private float flashlightAngerGainPerSecond;
    [SerializeField] private float uVLightAngerGainPerSecond;
    [SerializeField] private float angerDecayPerSecond;
    private Transform player;
    private PlayerFlashlight playerFlashlight;
    private PlayerUVLight playerUVLight;

    public float AngerMeter { get; private set; }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerFlashlight = GameObject.FindWithTag("Flashlight").GetComponent<PlayerFlashlight>();
        playerUVLight = GameObject.FindWithTag("UV Light").GetComponent<PlayerUVLight>();
    }

    private void Update()
    {
        if (playerFlashlight.IsFlashlightOn)
        {
            AngerMeter += flashlightAngerGainPerSecond * Time.deltaTime;
        }

        else if (playerUVLight.IsUVLightOn)
        {
            AngerMeter += uVLightAngerGainPerSecond * Time.deltaTime;
        }

        else
        {
            AngerMeter = Mathf.Max(0, AngerMeter - (uVLightAngerGainPerSecond * Time.deltaTime));
        }

        if (AngerMeter >= angerThreshold)
        {
            transform.position = player.position + new Vector3(0, -1, 0);
        }
    }
}
