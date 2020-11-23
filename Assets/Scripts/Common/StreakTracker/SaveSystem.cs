using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SaveTracker (StreakTracker tracker)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/tracker.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        StreakData data = new StreakData(tracker);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static StreakData LoadStreak()
    {
        string path = Application.persistentDataPath + "/tracker.game";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StreakData data = formatter.Deserialize(stream) as StreakData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
