using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float forwardMovement;
    private float rightMovement;
    private float verticalMouseMovement;
    private float horizontalMouseMovement;
    private bool startSprint;
    private bool stopSprint;

    public float ForwardMovement { get => forwardMovement; set => forwardMovement = value; }
    public float RightMovement { get => rightMovement; set => rightMovement = value; }
    public float VerticalMouseMovement { get => verticalMouseMovement; set => verticalMouseMovement = value; }
    public float HorizontalMouseMovement { get => horizontalMouseMovement; set => horizontalMouseMovement = value; }
    public bool StartSprint { get => startSprint; set => startSprint = value; } 
    public bool StopSprint { get => stopSprint; set => stopSprint = value; }


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
        startSprint = Input.GetKeyDown(KeyCode.LeftShift);
        stopSprint = Input.GetKeyUp(KeyCode.LeftShift);
    }
}
