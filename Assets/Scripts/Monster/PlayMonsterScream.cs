using UnityEngine;

public class PlayMonsterScream : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] screams;

    public void PlayScream()
    {
        audioSource.PlayOneShot(GetScream());
    }

    private AudioClip GetScream()
    {
        return screams[Random.Range(0, screams.Length)];
    }
}
