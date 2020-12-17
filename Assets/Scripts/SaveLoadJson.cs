using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using System.IO;

public class SaveLoadJson : MonoBehaviour
{
    private static string path;
    private static string json;
    void Awake()
    {
        path = Path.Combine(Application.dataPath, "Data.json");
    }
    private void Start()
    {
        json = JsonUtility.ToJson(ItemBehaviour.item);
    }
    private void Save()
    {
        json = JsonUtility.ToJson(ItemBehaviour.item);
        File.WriteAllText(path, json);
    }
    public static void Load()
    {
        if(path != null)
        {
            json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, ItemBehaviour.item);
        }
    }
    private void OnApplicationQuit()
    {
        Save();
    }
}
