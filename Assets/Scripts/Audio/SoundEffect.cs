using System;
using UnityEngine;

[Serializable]
public class SoundEffect
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] variations;

    public void PlaySoundEffect()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.2f);
        audioSource.PlayOneShot(GetVariation());
    }

    private AudioClip GetVariation()
    {
        return variations[UnityEngine.Random.Range(0, variations.Length)];
    }
}
