using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private PlayerSprint playerSprint;
    [SerializeField] private Image staminaBar;

    private void Start()
    {
        playerSprint = GameObject.Find("Player").GetComponent<PlayerSprint>();
    }

    private void Update()
    {
        UpdateStaminaBar();
    }

    private void UpdateStaminaBar()
    {
        staminaBar.fillAmount = playerSprint.RemainingSprintSeconds / playerSprint.MaximumSprintSeconds;
    }
}
