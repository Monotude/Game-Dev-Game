using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private PlayerSprint playerSprint;
    [SerializeField] private Image staminaBar;

    void Start()
    {
        playerSprint = GameObject.Find("Player").GetComponent<PlayerSprint>();
    }

    void Update()
    {
        staminaBar.fillAmount = playerSprint.RemainingSprintSeconds / playerSprint.MaximumSprintSeconds;
    }
}
