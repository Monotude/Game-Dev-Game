using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private PlayerSprint playerSprint;
    [SerializeField] private Image staminaBarFill;

    private void UpdateStaminaBar()
    {
        staminaBarFill.fillAmount = playerSprint.CurrentStamina / playerSprint.MaximumStamina;
    }

    private void Start()
    {
        playerSprint = GameObject.Find("Player").GetComponent<PlayerSprint>();
    }

    private void Update()
    {
        UpdateStaminaBar();
    }
}
