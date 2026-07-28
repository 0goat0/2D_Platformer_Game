using UnityEngine;
using System.IO;


public class SaveLoadManager : MonoBehaviour
{
    [SerializeField]
    PlayerData data;

    string fileName;
    string savePath;


    void Start()
    {
        data = new PlayerData();
        data.name = "goat";
        
        
        fileName = "playerData.json";
        savePath=Path.Combine(Application.persistentDataPath,fileName);

        Save();
    }
    void Save()
    {
        string json=JsonUtility.ToJson(data);

        File.WriteAllText(savePath,json);

        Debug.Log(savePath);
    }

}
