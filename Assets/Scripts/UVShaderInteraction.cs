using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVShaderInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private Material material;
    void Start()
    {
        material.SetFloat("_IsUvLightOn", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float isUvOn = playerUVLight.IsUVLightOn ? 1.0f : 0.0f;
        material.SetFloat("_IsUvLightOn", isUvOn);
    }
}
