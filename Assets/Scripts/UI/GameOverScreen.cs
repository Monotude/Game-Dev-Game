using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject respawn;
    [SerializeField] private float delay;
    [SerializeField] private AudioClip suspenseSound;
    private AudioSource audioSource;

    public void Setup()
    {
        InputManager.Instance.StopGameplayInput();
        AudioManager.Instance.PauseMusic();
        Cursor.lockState = CursorLockMode.Confined;

        audioSource = GetComponent<AudioSource>();

        gameObject.SetActive(true);
        text.SetActive(false);
        respawn.SetActive(false);
        StartCoroutine(ShowElementsAfterDelay());
    }

    private IEnumerator ShowElementsAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delay); // Use WaitForSecondsRealtime because timeScale is set to 0.
        Time.timeScale = 0f;

        PlaySound();
        text.SetActive(true);
        respawn.SetActive(true);
    }

    private void PlaySound()
    {
        if (audioSource != null && suspenseSound != null)
        {
            audioSource.PlayOneShot(suspenseSound); 
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        InputManager.Instance.IsPaused = false;
        AudioManager.Instance.ResumeMusic();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
