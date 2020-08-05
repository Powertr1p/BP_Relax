using System.Collections;
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
            Debug.Log(score * scoreMultiplier);
            StartCoroutine(UpdateScoreAnimation(score * scoreMultiplier));
        }

        private IEnumerator UpdateScoreAnimation(int scoreToAdd)
        {
            do
            {
                _score += 1;
                scoreToAdd -= 1;
                DisplayScore();
                yield return new WaitForSeconds(0.01f);
                
            } while (scoreToAdd != 0);
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
