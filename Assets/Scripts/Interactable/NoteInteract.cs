using UnityEngine;

public class NoteInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject note;
    [SerializeField] private AudioClip interactionSound; // Single sound for both actions
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    public void Interact()
    {
        note.SetActive(!note.activeInHierarchy);
        audioSource.PlayOneShot(interactionSound);

        if (note.activeInHierarchy)
        {
            PauseMenu.PauseGame();
        }
        else
        {
            PauseMenu.ResumeGame();
        }
    }
}
