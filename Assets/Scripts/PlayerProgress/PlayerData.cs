using System;

namespace PlayerProgress
{
    [Serializable]
    public class PlayerData
    {
        public int PlayerLevel;
        public float PlayerLevelProgress;
        
        public PlayerData(int level, float progress)
        {
            PlayerLevel = level;
            PlayerLevelProgress = progress;
        }
    }
}