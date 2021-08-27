using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void saveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveFile.owl";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveClass data = new SaveClass();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveClass loadData()
    {
        string path = Application.persistentDataPath + "/saveFile.owl";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveClass new_data = formatter.Deserialize(stream) as SaveClass;
            stream.Close();

            return new_data;

        }else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
