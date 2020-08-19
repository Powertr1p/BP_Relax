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

        [SerializeField] private int _scoreForOneStar = 500;
        [SerializeField] private int _scoreForTwoStars = 1000;
        [SerializeField] private int _scoreForThreeStars = 2000;

        private readonly float _delayBeforeScaleNextStar = 1f;
        private readonly float _defaultCornerStarSize = 1.3f;
        private readonly float _defaultMiddleStarSize = 1.5f;
        
        private IEnumerator Start()
        {
            if (_gameScore.GetScore >= _scoreForOneStar)
                StartCoroutine(ScaleUpStar(_leftStar, _defaultCornerStarSize));

            yield return new WaitForSecondsRealtime(_delayBeforeScaleNextStar);
            
            if (_gameScore.GetScore >= _scoreForTwoStars)
                StartCoroutine(ScaleUpStar(_middleStar, _defaultMiddleStarSize));

            yield return new WaitForSecondsRealtime(_delayBeforeScaleNextStar);
            
            if (_gameScore.GetScore >= _scoreForThreeStars)
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
