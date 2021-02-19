using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveLevelProgress(LevelProgressData data)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/levelProgress.fun";
        var stream = new FileStream(path, FileMode.Create);
            
        var levelProgressData = data;
        
        formatter.Serialize(stream, levelProgressData);   
        stream.Close();
    }

    public static LevelProgressData LoadLevelProgress()
    {
        var path = Application.persistentDataPath + "/levelProgress.fun";
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var levelProgressData = formatter.Deserialize(stream) as LevelProgressData;
            stream.Close();
            return levelProgressData;
        }
        else
        {
            Debug.LogError("Save file not found" + path);
            return new LevelProgressData(1);
        }
    }
}
