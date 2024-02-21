using UnityEngine;

public class ObjectiveKeys : MonoBehaviour
{
    [SerializeField] private bool hasObjectiveKey;

    // Start is called before the first frame update
    private void Start()
    {
        hasObjectiveKey = false;
    }
    public bool GetObjectiveKey()
    {
        return hasObjectiveKey;
    }

    public void SetObjectiveKey(bool status)
    {
        hasObjectiveKey = status;
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
