using UnityEngine;

public class InvisibleInk : MonoBehaviour
{
    [SerializeField] private PlayerUVLight playerUVLight;
    [SerializeField] private GameObject decal;

    private void Start()
    {
        decal.SetActive(false);
    }

    private void Update()
    {
        decal.SetActive(playerUVLight.IsUVLightOn);
    }
}
