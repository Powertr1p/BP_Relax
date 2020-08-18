using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GameOverScoreDisplay : MonoBehaviour
    {
        [SerializeField] private Score _gameScore;

        private TextMeshProUGUI _scoreText;
        
        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _scoreText.text = $"Score: {_gameScore.GetScore}";
        }
    }
}