using System;
using UnityEngine;

[Serializable]
public class Config
{
    [SerializeField] private bool isFullscreen;
    [SerializeField] private float mouseSensitivity;
    public bool IsFullscreen { get => this.isFullscreen; set => this.isFullscreen = value; }
    public float MouseSensitivity { get => this.mouseSensitivity; set => this.mouseSensitivity = value; }

    public Config()
    {
        IsFullscreen = true;
        MouseSensitivity = 300f;
    }
}
