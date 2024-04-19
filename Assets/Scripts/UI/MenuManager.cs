using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject optionsMenu;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        AudioManager.Instance.PlayMusic("Title Screen");
    }

    public void DeleteSave()
    {
        SaveManager.Instance.DeleteProgress();
    }

    public void PlayGame()
    {
        SaveManager.Instance.SaveConfig();
        SceneManager.LoadScene("Game");
    }

    public void OpenControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
