using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float verticalKeys;
    [SerializeField] private float horizontalKeys;

    public float VerticalKeys { get => verticalKeys; set => verticalKeys = value; }
    public float HorizontalKeys { get => horizontalKeys; set => horizontalKeys = value; }

    void Update()
    {
        verticalKeys = Input.GetAxisRaw("Vertical");
        horizontalKeys = Input.GetAxisRaw("Horizontal");
    }
}
