using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] musicSounds, sFXSounds;
    [SerializeField] private AudioSource musicSource, sFXSource;

    public static AudioManager Instance { get; private set; }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, sound => sound.Name == name);
        musicSource.clip = sound.AudioClip;
        musicSource.Play();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sFXSounds, sound => sound.Name == name);
        sFXSource.PlayOneShot(sound.AudioClip);
    }

    public void StopSFX()
    {
        sFXSource.Stop();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}

[Serializable]
internal class Sound
{
    [SerializeField] private string name;
    [SerializeField] private AudioClip audioClip;

    public string Name { get => this.name; set => this.name = value; }
    public AudioClip AudioClip { get => this.audioClip; set => this.audioClip = value; }
}