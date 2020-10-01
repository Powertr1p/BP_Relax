using PlayerProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuLevelProgressDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private Slider _progressSlider;

        private void Start()
        {
            LoadPlayerData();
        }

        private void LoadPlayerData()
        {
            var loadedData = SavingSystem.LoadPlayer();
            _currentLevelText.text = $"Level: {loadedData.PlayerLevel.ToString()}";
            _progressSlider.value = loadedData.PlayerLevelProgress;
        }
    }
}
