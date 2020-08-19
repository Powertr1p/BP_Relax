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
            StartCoroutine(CountScoreByOne());
        }
        
        private IEnumerator CountScoreByOne()
        {
            int score = 0;

            do
            {
                score += 1;
                ScoreUpated?.Invoke(score);
                yield return new WaitForSecondsRealtime(0.0001f);

            } while (score < _gameScore.GetScore);
        }
    }
}
