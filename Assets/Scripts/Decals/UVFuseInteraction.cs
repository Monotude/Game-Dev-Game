using UnityEngine;

public class UVFuseInteraction : MonoBehaviour
{
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private Material material;
    private float isUvOn;

    void Start()
    {
        material.SetFloat("_IsUvLightOn", 0.0f);
    }

    void Update()
    {
        isUvOn = playerUVLight.IsUVLightOn? 1.0f : 0.0f;
        material.SetFloat("_IsUvLightOn", isUvOn);
    }
}
