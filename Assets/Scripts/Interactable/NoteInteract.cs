using UnityEngine;

public class NoteInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject note;

    public void Interact()
    {
        note.SetActive(true);
        PauseMenu.PauseGame();
    }
}
