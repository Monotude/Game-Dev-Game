using System;
using UnityEngine;

[Serializable]
public class SoundEffect
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] variations;
    [Range(0.01f, 20f)]
    [SerializeField] private float minPitchVariation;
    [Range(0.01f, 20f)]
    [SerializeField] private float maxPitchVariation;

    public void PlaySoundEffect()
    {
        audioSource.pitch = UnityEngine.Random.Range(minPitchVariation, maxPitchVariation);
        audioSource.PlayOneShot(GetVariation());
    }

    private AudioClip GetVariation()
    {
        return variations[UnityEngine.Random.Range(0, variations.Length)];
    }
}
