using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private string progressFileName;
    [SerializeField] private string configFileName;

    public static SaveManager Instance { get; private set; }

    public ProgressManager GetProgressManager()
    {
        return GameObject.FindWithTag("Progress Manager")?.GetComponent<ProgressManager>();
    }

    public OptionsMenu GetOptionsMenu()
    {
        return GameObject.FindWithTag("UI Controller")?.GetComponent<OptionsMenu>();
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

    public void SaveConfig()
    {
        string path = Application.persistentDataPath + "/" + configFileName + ".json";
        string json = JsonUtility.ToJson(GetOptionsMenu()?.Config);
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

        progressManager.Progress ??= new Progress(progressManager.FuseCount);
    }

    public void LoadConfig()
    {
        string path = Application.persistentDataPath + "/" + configFileName + ".json";
        OptionsMenu optionsMenu = GetOptionsMenu();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            optionsMenu.Config = JsonUtility.FromJson<Config>(json);
        }

        optionsMenu.Config ??= new Config();
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
}