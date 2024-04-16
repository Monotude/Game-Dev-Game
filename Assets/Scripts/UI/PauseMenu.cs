using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isGamePaused;

    public static void PauseGame()
    {
        Time.timeScale = 0f;
        InputManager.Instance.StopGameplayInput();
        AudioManager.Instance.PauseMusic();
        Cursor.lockState = CursorLockMode.Confined;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        InputManager.Instance.IsPaused = false;
        AudioManager.Instance.ResumeMusic();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!InputManager.Instance.PauseMenuButtonDown)
        {
            return;
        }

        if (!isGamePaused)
        {
            isGamePaused = true;
            PauseGame();
            pauseMenu.SetActive(true);
        }

        else
        {
            isGamePaused = false;
            ResumeGame();
            pauseMenu.SetActive(false);
        }
    }
}
