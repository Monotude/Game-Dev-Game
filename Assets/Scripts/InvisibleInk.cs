using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleInk : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private GameObject decal;
    void Start()
    {
        decal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        decal.SetActive(playerUVLight.IsUVLightOn);
    }
}
