using UnityEngine;

public class SubjectGammaSounds : MonoBehaviour
{
    [SerializeField] private float angerMeterLevelToWarn;
    private SubjectGammaBehaviour subjectGammaBehaviour;
    private AudioSource audioSource;
    private bool isWarning;

    private void Start()
    {
        subjectGammaBehaviour = GetComponent<SubjectGammaBehaviour>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (subjectGammaBehaviour.AngerMeter >= angerMeterLevelToWarn && !isWarning)
        {
            isWarning = true;
            audioSource.Play();
        }

        else if (subjectGammaBehaviour.AngerMeter < angerMeterLevelToWarn && isWarning)
        {
            isWarning = false;
            audioSource.Stop();
        }
    }
}
