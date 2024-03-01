using UnityEngine;

public class FuseBoxSaveLoad : MonoBehaviour
{
    [SerializeField] private GameObject fuse;
    [SerializeField] private int fuseBoxNumber;

    private void Start()
    {
        if (ObjectiveManager.Instance.Objective.IsFuseBoxPowered(fuseBoxNumber))
        {
            fuse.SetActive(true);
        }
    }
}
