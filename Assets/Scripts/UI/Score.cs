using PlayerInput;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private OnBubbleHitHandler _hitHandler;
        [SerializeField] private PopComboDetector.PopComboDetector _comboDetector;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _score;
        public int GetScore => _score;

        private void OnEnable()
        {
            _hitHandler.OnBubblePopped += UpdateScore;
        }

        private void Start()
        {
            DisplayScore();
        }

        private void UpdateScore(int score)
        {
            var scoreMultiplier = _comboDetector.ScoreMultiplier != 0 ? _comboDetector.ScoreMultiplier : 1;
            _score += score * scoreMultiplier;

            if (_score < 0)
                _score = 0;
            
            DisplayScore();
        }

        private void DisplayScore()
        {
            _scoreText.text = _score.ToString();
        }

        private void OnDisable()
        {
            _hitHandler.OnBubblePopped -= UpdateScore;
        }
    }
}
