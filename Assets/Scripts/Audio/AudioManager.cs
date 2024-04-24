using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Music[] music;
    [SerializeField] private Sound[] sounds;
    [SerializeField] private AudioSource musicSource, sFXSource;

    public static AudioManager Instance { get; private set; }

    public void PlayMusic(string name)
    {
        Music song = Array.Find(music, sound => sound.Name == name);
        musicSource.clip = song.AudioClip;
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
        Sound sound = Array.Find(sounds, sound => sound.Name == name);
        sound.SoundEffect.PlaySoundEffect();
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
internal class Music
{
    [SerializeField] private string name;
    [SerializeField] private AudioClip audioClip;

    public string Name => this.name;
    public AudioClip AudioClip => this.audioClip;
}

[Serializable]
internal class Sound
{
    [SerializeField] private string name;
    [SerializeField] private SoundEffect soundEffect;

    public string Name => this.name;
    public SoundEffect SoundEffect => this.soundEffect;
}