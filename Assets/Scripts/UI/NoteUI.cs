using UnityEngine;

public class NoteUI : MonoBehaviour
{
    public void CloseNote(GameObject note)
    {
        note.SetActive(false);
        PauseMenu.ResumeGame();
    }
}
