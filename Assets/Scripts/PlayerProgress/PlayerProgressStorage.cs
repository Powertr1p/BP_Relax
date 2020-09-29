using System;
using UI;
using UnityEngine;

namespace PlayerProgress
{
    public class PlayerProgressStorage : MonoBehaviour
    {
        public int Level { get; private set; }
        public float Progress { get; private set; }

        private float _progressMaxValue = 1f;

        private void Awake()
        {
            LoadPlayerData();
        }

        public void UpdateCurrentData(int level, float progress)
        {
            Level = level;
            Progress = progress;
        }
        
        private void LoadPlayerData()
        {
            var loadedData = SavingSystem.LoadPlayer();
            Level = loadedData.PlayerLevel;
            Progress = loadedData.PlayerLevelProgress;
        }

        private void StorageCurrentData()
        {
            while (Progress >= _progressMaxValue)
            {
                Progress -= _progressMaxValue;
                Level++;
            }

            var currentData = new PlayerData(Level, Progress);
            SavingSystem.SavePlayer(currentData);
        }

        private void OnDisable()
        {
            StorageCurrentData();
        }
    }
}