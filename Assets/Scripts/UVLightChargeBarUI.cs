using UnityEngine;
using UnityEngine.UI;

public class UVLightChargeBarUI : MonoBehaviour
{
    private PlayerUVLight playerUVLight;
    [SerializeField] private Image uVLightBarFill;

    private void UpdateUVLightBar()
    {
        uVLightBarFill.fillAmount = playerUVLight.CurrentCharges / playerUVLight.MaxCharges;
    }

    private void Start()
    {
        playerUVLight = GameObject.Find("UV Light").GetComponent<PlayerUVLight>();
    }

    private void Update()
    {
        UpdateUVLightBar();
    }
}
