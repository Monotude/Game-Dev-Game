using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float forwardMovement;
    private float rightMovement;
    private float verticalMouseMovement;
    private float horizontalMouseMovement;
    private bool sprintButtonDown;
    private bool sprintButtonUp;
    private bool flashlightButtonDown;
    private bool uVLightButtonDown;

    public float ForwardMovement { get => forwardMovement; set => forwardMovement = value; }
    public float RightMovement { get => rightMovement; set => rightMovement = value; }
    public float VerticalMouseMovement { get => verticalMouseMovement; set => verticalMouseMovement = value; }
    public float HorizontalMouseMovement { get => horizontalMouseMovement; set => horizontalMouseMovement = value; }
    public bool SprintButtonDown { get => sprintButtonDown; set => sprintButtonDown = value; }
    public bool SprintButtonUp { get => sprintButtonUp; set => sprintButtonUp = value; }
    public bool FlashlightButtonDown { get => flashlightButtonDown; set => flashlightButtonDown = value; }
    public bool UVLightButtonDown { get => uVLightButtonDown; set => uVLightButtonDown = value; }

    private void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        forwardMovement = Input.GetAxisRaw("Vertical");
        rightMovement = Input.GetAxisRaw("Horizontal");
        verticalMouseMovement = Input.GetAxisRaw("Mouse Y");
        horizontalMouseMovement = Input.GetAxisRaw("Mouse X");
        sprintButtonDown = Input.GetKeyDown(KeyCode.LeftShift);
        sprintButtonUp = Input.GetKeyUp(KeyCode.LeftShift);
        flashlightButtonDown = Input.GetKeyDown(KeyCode.Mouse0);
        uVLightButtonDown = Input.GetKeyDown(KeyCode.Mouse1);
    }
}
