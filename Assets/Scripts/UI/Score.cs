using System;
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
            StartCoroutine(UpdateScoreAnimation(score * scoreMultiplier));
        }

        private IEnumerator UpdateScoreAnimation(int scoreToAdd)
        {
            var pointToAdd = scoreToAdd < 0 ? -1 : 1;
            scoreToAdd = Math.Abs(scoreToAdd);
            
            do
            {
                _score += pointToAdd;
                scoreToAdd -= 1;
                DisplayScore();
                
                yield return new WaitForSeconds(0.01f);
                
            } while (scoreToAdd > 0 && _score > 0);
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
