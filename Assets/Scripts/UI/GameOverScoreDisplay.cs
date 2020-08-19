using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GameOverScoreDisplay : MonoBehaviour
    {
        [SerializeField] private GameOverScoreCounter _scoreCounter;

        private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _scoreCounter.ScoreUpated += DisplayScore;
        }

        private void DisplayScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreUpated -= DisplayScore;
        }
    }
}