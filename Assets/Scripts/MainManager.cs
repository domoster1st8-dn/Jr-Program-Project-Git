using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor; // new variable declared
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    [System.Serializable]
    class DataSave
    {
        public Color colorTeam;
    }
    public void SaveColor()
    {
        DataSave data = new DataSave();
        data.colorTeam = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataSave data = JsonUtility.FromJson<DataSave>(json);

            TeamColor = data.colorTeam;
        }
    }

}

