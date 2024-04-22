using UnityEngine;

public class UVShaderInteraction : MonoBehaviour
{
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private Material material;
    private UnityEngine.Rendering.Universal.DecalProjector decal;
    private float isUvOn;

    void Start()
    {
        decal = gameObject.GetComponent<UnityEngine.Rendering.Universal.DecalProjector>();
        material.SetFloat("_IsUvLightOn", 0.0f);
    }

    void Update()
    {
        isUvOn = playerUVLight.IsUVLightOn? 1.0f : 0.0f;
        decal.drawDistance = playerUVLight.IsUVLightOn? 7.0f : 1000.0f;
        material.SetFloat("_IsUvLightOn", isUvOn);
    }
}
