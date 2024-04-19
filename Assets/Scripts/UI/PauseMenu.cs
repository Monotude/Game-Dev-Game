using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject restartConfirmation;
    [SerializeField] private GameObject quitConfirmation;
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

    public void ExitPauseMenu()
    {
        isGamePaused = false;
        ResumeGame();
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        restartConfirmation.SetActive(false);
        quitConfirmation.SetActive(false);
    }

    public void OpenControlsMenu()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void OpenOptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Restart()
    {
        SaveManager.Instance.SaveProgress();
        SaveManager.Instance.SaveConfig();
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void Quit(string sceneName)
    {
        SaveManager.Instance.SaveProgress();
        SaveManager.Instance.SaveConfig();
        SceneManager.LoadScene(sceneName);
    }

    public void OpenConfirmation(GameObject confirmation)
    {
        confirmation.SetActive(true);
    }

    public void CloseConfirmation(GameObject confirmation)
    {
        confirmation.SetActive(false);
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
            ExitPauseMenu();
        }
    }
}
