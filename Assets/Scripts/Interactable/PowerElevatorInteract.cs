using UnityEngine;

public class PowerElevatorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private OpenElevatorDoors openElevatorDoors;
    [SerializeField] private GameObject theGang;
    [SerializeField] private Material material;

    private void Start()
    {
        material.color = Color.red;
    }

    public void Interact()
    {
        material.color = Color.green;
        openElevatorDoors.StartElevatorProgress();
        theGang.SetActive(true);
        RenderSettings.ambientLight = new Color(0, 0, 0, 0);
    }
}
