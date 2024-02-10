using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{
    [Header("Bobbing Parameters")]
    [SerializeField] private float horizontalBobFrequency;
    [SerializeField] private float verticalBobFrequency;
    [SerializeField] private float bobAmplitude;
    [SerializeField] private float verticalOffset;

    [Header("Timing Parameters")]
    [SerializeField] private float strideSpeedMultiplier;
    [SerializeField] private float lerpSpeed; 

    private float timer;
    private bool isMoving;

    private void Update()
    {
        isMoving = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

        if (isMoving)
        {
            float horizontalBob = Mathf.Sin(timer * horizontalBobFrequency) * bobAmplitude;
            float verticalBob = Mathf.Abs(Mathf.Cos(timer * verticalBobFrequency * 2f)) * bobAmplitude;

            Vector3 targetBobPosition = new Vector3(horizontalBob, verticalBob, 0f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetBobPosition + Vector3.up * verticalOffset, Time.deltaTime * lerpSpeed);

            timer += Time.deltaTime * strideSpeedMultiplier;
        }
        else
        {
            timer = 0f;
        }
    }
}
