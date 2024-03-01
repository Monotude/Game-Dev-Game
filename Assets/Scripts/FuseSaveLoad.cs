using UnityEngine;

public class FuseSaveLoad : MonoBehaviour
{
    [SerializeField] private int fuseNumber;

    private void Start()
    {
        if (ObjectiveManager.Instance.Objective.IsFuseCollected(fuseNumber))
        {
            Destroy(gameObject);
        }
    }
}
