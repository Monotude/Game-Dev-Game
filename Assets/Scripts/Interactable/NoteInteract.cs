using UnityEngine;

public class NoteInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject note;

    public void Interact()
    {
        AudioManager.Instance.PlaySFX("Paper SFX");
        note.SetActive(true);
        PauseMenu.PauseGame();
    }
}
