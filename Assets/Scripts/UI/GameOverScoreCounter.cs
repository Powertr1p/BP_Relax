using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class GameOverScoreCounter : MonoBehaviour
    {
        [SerializeField] private Score _gameScore;

        public event Action<int> ScoreUpated;
        
        private void Start()
        {
            if (_gameScore.GetScore <= 0) return;
            StartCoroutine(CountScoreByOne());
        }
        
        private IEnumerator CountScoreByOne()
        {
            int score = 0;

            do
            {
                score += (_gameScore.GetScore - score) / 10 > 0 ? 10 : 1;
                ScoreUpated?.Invoke(score);
                
                yield return new WaitForSecondsRealtime(0);
            } while (score < _gameScore.GetScore);
        }
    }
}
