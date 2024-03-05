using System;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private bool isPowerOn;
    [SerializeField] private int fuseCount;
    [SerializeField] private GameObject monster;

    public int FuseCount { get => this.fuseCount; set => this.fuseCount = value; }
    public Progress Progress { get; set; }
    public event Action LoadGame;

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Section 1 Horror");
        SaveManager.Instance.LoadProgress(this);
        LoadGame?.Invoke();
    }

    private void Update()
    {
        if (isPowerOn)
        {
            return;
        }

        for (int i = 1; i <= fuseCount; ++i)
        {
            if (Progress.IsFuseCollected(i))
            {
                monster.SetActive(true);
            }
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
        Destroy(monster);
        AudioManager.Instance.StopMusic();
    }
}
