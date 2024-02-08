using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{   
    [Header("Bobbing Parameters")]
    public float horizontalBobFrequency = 0f;  // Frequency of the bobbing motion
    public float verticalBobFrequency = 1.5f; 
    public float bobAmplitude = 0.15f; // Amplitude of the bobbing motion
    public float verticalOffset = 0.6f; // How high the camera is

    [Header("Timing Parameters")]
    public float strideSpeedMultiplier = 1.0f; // Adjust this to match the character's movement speed
    public float lerpSpeed = 10.0f; // Smoothness of the bobbing motion

    private float timer = 0.0f;
    private bool isMoving = false;
    private bool isRunning = false;

    private void Update()
    {
        // Check if the player is moving (you can replace this condition with your movement check logic)
        isMoving = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;
        isRunning = GetComponentInParent<PlayerMovement>().running;


        if (isMoving)
        {
            if (isRunning)
                verticalBobFrequency = 3.0f;
            else
                verticalBobFrequency = 1.5f;

            // Calculate the sinusoidal bobbing motion
            float horizontalBob = Mathf.Sin(timer * horizontalBobFrequency) * bobAmplitude;
            float verticalBob = Mathf.Abs(Mathf.Cos(timer * verticalBobFrequency * 2f)) * bobAmplitude;

            // Apply the bobbing motion to the camera's position
            Vector3 targetBobPosition = new Vector3(horizontalBob, verticalBob, 0f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetBobPosition + Vector3.up * verticalOffset, Time.deltaTime * lerpSpeed);

            timer += Time.deltaTime * strideSpeedMultiplier;
        }
        else
        {
            // idle
            timer = 0f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero + Vector3.up * verticalOffset, Time.deltaTime * lerpSpeed);
        }
    }
}