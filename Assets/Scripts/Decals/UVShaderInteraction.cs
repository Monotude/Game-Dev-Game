using UnityEngine;

public class UVShaderInteraction : MonoBehaviour
{
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private Material material;

    void Start()
    {
        material.SetFloat("_IsUvLightOn", 0.0f);
    }

    void Update()
    {
        float isUvOn = playerUVLight.IsUVLightOn ? 1.0f : 0.0f;
        material.SetFloat("_IsUvLightOn", isUvOn);
    }
}
