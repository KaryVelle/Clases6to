using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public List<string> llavesIds = new List<string>();
}

public class SaveSystem : ISaveSystem
{
    private const string ClavePlayerPrefs = "Partida";

    public void SaveKeys(IEnumerable<string> ids)
    {
        SaveData data = new SaveData { llavesIds = new List<string>(ids) };
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(ClavePlayerPrefs, json);
        PlayerPrefs.Save();
        Debug.Log("<color=blue>JSON</color>" + json);
        Debug.Log("<color=green>Data</color>" + data);
    }

    public HashSet<string> LoadKeys()
    {
        if (!PlayerPrefs.HasKey(ClavePlayerPrefs))
            return new HashSet<string>();

        string json = PlayerPrefs.GetString(ClavePlayerPrefs);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return new HashSet<string>(data.llavesIds);
    }
}