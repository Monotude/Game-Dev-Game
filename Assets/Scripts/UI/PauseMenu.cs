using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isGamePaused;

    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        InputManager.Instance.IsPaused = true;
        AudioManager.Instance.PauseMusic();
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        InputManager.Instance.IsPaused = false;
        AudioManager.Instance.ResumeMusic();
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (!InputManager.Instance.PauseMenuButtonDown)
        {
            return;
        }

        if (!isGamePaused)
        {
            PauseGame();
        }

        else
        {
            ResumeGame();
        }
    }
}
