using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] private GameObject controlsMenu;

    public void BackButton(GameObject menuToGoBackTo)
    {
        controlsMenu.SetActive(false);
        menuToGoBackTo.SetActive(true);
    }
}
