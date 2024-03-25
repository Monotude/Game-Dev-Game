using UnityEngine;

public class MonsterScream : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] screams;
    

    public void PlayMonsterScream()
    {
        audioSource.PlayOneShot(GetMonsterScream());
    }

    
    private AudioClip GetMonsterScream()
    {
        return screams[Random.Range(0, screams.Length)];
    }

    
}
