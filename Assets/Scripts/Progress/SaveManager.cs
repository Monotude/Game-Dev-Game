using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private string progressFileName;

    public static SaveManager Instance { get; private set; }

    public ProgressManager GetProgressManager()
    {
        return GameObject.FindWithTag("Progress Manager")?.GetComponent<ProgressManager>();
    }

    public void DeleteProgress()
    {
        string path = Application.persistentDataPath + "/" + progressFileName + ".json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public void SaveProgress()
    {
        string path = Application.persistentDataPath + "/" + progressFileName + ".json";
        string json = JsonUtility.ToJson(GetProgressManager()?.Progress);
        File.WriteAllText(path, json);
    }

    public void LoadProgress()
    {
        string path = Application.persistentDataPath + "/" + progressFileName + ".json";
        ProgressManager progressManager = GetProgressManager();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            progressManager.Progress = JsonUtility.FromJson<Progress>(json);
        }
        else
        {
            progressManager.Progress = new Progress(progressManager.FuseCount);
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
        SaveProgress();
    }
}