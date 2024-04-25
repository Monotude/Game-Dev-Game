using UnityEngine;

public class PowerElevatorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private OpenElevatorDoors openElevatorDoors;
    [SerializeField] private GameObject theGang;
    [SerializeField] private Material material;
    [SerializeField] private Animator section1DoorLeft;
    [SerializeField] private Animator section1DoorRight;
    [SerializeField] private Animator section2DoorLeft;
    [SerializeField] private Animator section2DoorRight;

    private void Start()
    {
        material.color = Color.red;
    }

    public void Interact()
    {
        if (!theGang.activeSelf)
        {
            material.color = Color.green;
            openElevatorDoors.StartElevatorProgress();
            theGang.SetActive(true);
            RenderSettings.ambientLight = new Color(0, 0, 0, 0);
            AudioManager.Instance.PlayMusic("Section 1 Horror");
            section1DoorLeft.Play("DoorCloseLeft");
            section1DoorRight.Play("DoorCloseRight");
            section2DoorLeft.Play("DoorCloseLeft");
            section2DoorRight.Play("DoorCloseRight");
        }
    }
}
