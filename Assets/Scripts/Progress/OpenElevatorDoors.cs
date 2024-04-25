using UnityEngine;

public class OpenElevatorDoors : MonoBehaviour
{
    [SerializeField] private GameObject progressBar;

    public void Awake()
    {
        progressBar.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    public void StartElevatorProgress()
    {
        Destroy(gameObject.GetComponent<Collider>());
        progressBar.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        gameObject.GetComponent<Animator>().Play("ElevatorProgressBar");
    }

    public void OpenDoors()
    {
        gameObject.GetComponent<Animator>().Play("ElevatorOpen");
    }
}
