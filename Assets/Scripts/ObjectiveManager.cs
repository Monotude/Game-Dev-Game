using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    private bool isPowerOn;
    [SerializeField] private int fusesCount;
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject monster;

    public static ObjectiveManager Instance { get; private set; }
    public int FuseCollectedCount { get; set; }
    public bool[] IsFuseBoxPowered { get; set; }
    public bool[] IsElectricalBoxOn { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        IsFuseBoxPowered = new bool[fusesCount];
        IsElectricalBoxOn = new bool[fusesCount];
    }

    private void Update()
    {
        foreach (bool isOn in IsElectricalBoxOn)
        {
            if (!isOn)
            {
                return;
            }
        }

        if (!isPowerOn)
        {
            isPowerOn = true;
            RenderSettings.ambientLight = new Color32(150, 150, 150, 0);
            lights.SetActive(true);
            Destroy(monster);
        }
    }
}
