using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private int fusesCount;
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject monster;

    public static ObjectiveManager Instance { get; private set; }
    public int FuseCollectedCount { get; set; }
    public bool[] IsFuseBoxPowered { get; set; }
    public bool[] IsElectricalBoxPowered { get; set; }

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
        IsElectricalBoxPowered = new bool[fusesCount];
    }

    private void Update()
    {
        foreach (bool powered in IsElectricalBoxPowered)
        {
            if (!powered)
            {
                return;
            }
        }

        lights.SetActive(true);
        Destroy(monster);
    }
}
