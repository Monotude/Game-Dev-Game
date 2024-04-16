using System;
using UnityEngine;

public class Section2PowerOff : MonoBehaviour
{
    private ProgressManager progressManager;

    public Action lightsOffEvent;

    private void TurnOffLights()
    {
        if (!progressManager.Progress.GetIsSection2Cleared())
        {
            progressManager.Progress.StartSection2();
            lightsOffEvent?.Invoke();
            RenderSettings.ambientLight = new Color32(0, 0, 0, 0);
        }
    }

    private void Awake()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        lightsOffEvent += progressManager.StartSection2;
    }
}
