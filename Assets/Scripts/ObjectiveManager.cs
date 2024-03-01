using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    private bool isPowerOn;
    [SerializeField] private int fuseCount;

    public static ObjectiveManager Instance { get; private set; }
    public Objective Objective { get; set; }
    public int FuseCount { get => this.fuseCount; set => this.fuseCount = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GetComponent<ObjectiveSave>().LoadObjective();
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isPowerOn)
        {
            return;
        }

        for (int i = 1; i <= fuseCount; ++i)
        {
            if (!Objective.IsElectricalBoxOn(i))
            {
                return;
            }
        }

        isPowerOn = true;
        RenderSettings.ambientLight = new Color32(100, 100, 100, 0);
        Destroy(GameObject.FindWithTag("Monster"));
    }
}
