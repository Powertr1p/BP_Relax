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
                if ((_gameScore.GetScore - score) / 10 > 0)
                    score += 10;
                else
                    score++;

                ScoreUpated?.Invoke(score);
                yield return new WaitForSecondsRealtime(0);

            } while (score < _gameScore.GetScore);
        }
    }
}
