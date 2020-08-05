using System;
using PlayerInput;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private OnBubbleHitHandler _hitHandler;
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
            _score += score;
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
