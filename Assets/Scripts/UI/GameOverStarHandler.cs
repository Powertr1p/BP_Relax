using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverStarHandler : MonoBehaviour
    {
        [SerializeField] private Score _gameScore;
        
        [SerializeField] private Image _leftStar;
        [SerializeField] private Image _middleStar;
        [SerializeField] private Image _rightStar;

        private readonly float _defaultCornerStarSize = 1.3f;
        private readonly float _defaultMiddleStarSize = 1.5f;
        
        private void Start()
        {
            if (_gameScore.GetScore >= 500)
                StartCoroutine(ScaleUpStar(_leftStar, _defaultCornerStarSize));
            if (_gameScore.GetScore >= 1000)
                StartCoroutine(ScaleUpStar(_middleStar, _defaultMiddleStarSize));
            if (_gameScore.GetScore >= 2000)
                StartCoroutine(ScaleUpStar(_rightStar, _defaultCornerStarSize));
        }

        private IEnumerator ScaleUpStar(Image star, float defaultStarSize)
        {
            Vector3 sizeToAdd = new Vector3(0.05f, 0.05f, 0.1f);

            while (star.rectTransform.localScale.x < defaultStarSize)
            {
                star.rectTransform.localScale += sizeToAdd;
                yield return new WaitForSecondsRealtime(0.05f);
            } 
        }
    }
}
