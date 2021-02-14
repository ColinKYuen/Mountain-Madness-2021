using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData()
    {
        string path = Application.persistentDataPath + "/Player.xyz";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fstream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();
        formatter.Serialize(fstream, data);
        fstream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/Player.xyz";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fstream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(fstream) as SaveData;
            fstream.Close();

            return data;
        }
        else
        {
            Debug.LogError("No Save File at " + path);
            return null;
        }
    }
}

