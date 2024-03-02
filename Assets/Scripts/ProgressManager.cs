using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private bool isPowerOn;
    [SerializeField] private int fuseCount;

    public int FuseCount { get => this.fuseCount; set => this.fuseCount = value; }
    public Progress Progress { get; set; }

    private void Awake()
    {
        SaveManager.Instance.LoadProgress(this);
    }

    private void Update()
    {
        if (isPowerOn)
        {
            return;
        }

        for (int i = 1; i <= fuseCount; ++i)
        {
            if (!Progress.IsElectricalBoxOn(i))
            {
                return;
            }
        }

        isPowerOn = true;
        RenderSettings.ambientLight = new Color32(60, 60, 60, 0);
        Destroy(GameObject.FindWithTag("Monster"));
    }
}
