using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PlayerProgress
{
    public static class SavingSystem
    {
        private const string SavePath = "playerSavedData.data";
        
        public static void SavePlayer(PlayerData progress)
        {
            string path = Path.Combine(Application.persistentDataPath, SavePath);

            BinaryFormatter formatter = new BinaryFormatter();
            PlayerData data = new PlayerData(progress.PlayerLevel, progress.PlayerLevelProgress);
            
            using (FileStream stream = new FileStream(path, FileMode.Create))
                formatter.Serialize(stream, data);
        }

        public static PlayerData LoadPlayer()
        {
            string path = Path.Combine(Application.persistentDataPath, SavePath);
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    PlayerData data = formatter.Deserialize(stream) as PlayerData;
                    return data;
                }
            }

            return GetNewPlayerData();
        }

        private static PlayerData GetNewPlayerData()
        {
            return new PlayerData(1,0f);
        }
    }
}