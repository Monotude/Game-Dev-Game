using UnityEngine;

public class NoteUI : MonoBehaviour
{
    [SerializeField] private GameObject note;

    public void CloseNote(GameObject note)
    {
        note.SetActive(false);
        PauseMenu.ResumeGame();
    }
}
