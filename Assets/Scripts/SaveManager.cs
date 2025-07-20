using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string saveFilePath;

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "sessionData.json");
    }

    public SessionData LoadSession()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SessionData data = JsonUtility.FromJson<SessionData>(json);
            Debug.Log("Save file loaded.");
            return data;
        }
        else
        {
            Debug.Log("No save file found. Creating new session.");
            return null; // Return null if no save file exists
        }
    }

    public void SaveSession(SessionData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Session saved to: " + saveFilePath);
    }
    public void DeleteSaveFile()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "sessionData.json");
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("Save file deleted.");
        }
    }
}