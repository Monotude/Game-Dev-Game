using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    private ProgressManager progressManager;
    [SerializeField] private Image fuseIcon;
    [SerializeField] private TextMeshProUGUI fuseCountText;

    private void Awake()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        progressManager.LoadGame += UpdateFuseUI;
    }

    public void UpdateFuseUI()
    {
        int fuseCount = progressManager.Progress.GetFuseCount();

        if (fuseCount == 0)
        {
            fuseIcon.enabled = false;
            fuseCountText.enabled = false;
            return;
        }

        fuseIcon.enabled = true;
        fuseCountText.enabled = true;
        fuseCountText.text = fuseCount.ToString();
    }
}
