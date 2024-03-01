using System.IO;
using UnityEngine;

public class ObjectiveSave : MonoBehaviour
{
    [SerializeField] private string fileName;

    public static ObjectiveSave Instance { get; private set; }

    public void SaveObjective()
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        string json = JsonUtility.ToJson(ObjectiveManager.Instance.Objective);
        File.WriteAllText(path, json);
    }

    public void LoadObjective()
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ObjectiveManager.Instance.Objective = JsonUtility.FromJson<Objective>(json);
        }
        else
        {
            ObjectiveManager.Instance.Objective = new Objective(ObjectiveManager.Instance.FuseCount);
        }
    }

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

    private void OnApplicationQuit()
    {
        SaveObjective();
    }
}