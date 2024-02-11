using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float ForwardMovement { get; set; }
    public float RightMovement { get; set; }
    public float VerticalMouseMovement { get; set; }
    public float HorizontalMouseMovement { get; set; }
    public bool SprintButtonDown { get; set; }
    public bool SprintButtonUp { get; set; }
    public bool FlashlightButtonDown { get; set; }
    public bool UVLightButtonDown { get; set; }

    private void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        ForwardMovement = Input.GetAxisRaw("Vertical");
        RightMovement = Input.GetAxisRaw("Horizontal");
        VerticalMouseMovement = Input.GetAxisRaw("Mouse Y");
        HorizontalMouseMovement = Input.GetAxisRaw("Mouse X");
        SprintButtonDown = Input.GetKeyDown(KeyCode.LeftShift);
        SprintButtonUp = Input.GetKeyUp(KeyCode.LeftShift);
        FlashlightButtonDown = Input.GetKeyDown(KeyCode.Mouse0);
        UVLightButtonDown = Input.GetKeyDown(KeyCode.Mouse1);
    }
}
