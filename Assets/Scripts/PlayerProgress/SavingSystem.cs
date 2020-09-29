using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PlayerProgress
{
    public static class SavingSystem
    {
        public static void SavePlayer(PlayerData progress)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/playerSavedData.data";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            PlayerData data = new PlayerData(progress.PlayerLevel, progress.PlayerLevelProgress);
            
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/playerSavedData.data";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return data;
            }
            else
            {
                return new PlayerData(1,0f);
            }
        }
    }
}