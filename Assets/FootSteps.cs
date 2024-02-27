using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioClip[] clipsRun;

    private AudioSource audioSource;

    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    
    private void StepRun()
    {
        AudioClip clipsRun = GetRandomClipRun();
        audioSource.PlayOneShot(clipsRun);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    private AudioClip GetRandomClipRun()
    {
        return clipsRun[UnityEngine.Random.Range(0, clipsRun.Length)];
    }

}
