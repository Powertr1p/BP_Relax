using System.Collections;
using PlayerInput;
using SlowMode;
using UnityEngine;
using UnityEngine.UI;

namespace VFX
{
    public class SlowStateCircleEffectHandler : MonoBehaviour
    {
        [SerializeField] private Image _effectImage;
        [SerializeField] private TapDetector _tapDetector;
        [SerializeField] private SlowStateToggler _slowStateToggler;
        [SerializeField] private Vector3 _sizeToAdd = new Vector3(0.3f, 0.3f, 0);

        private IEnumerator _coroutine;
        private Color _defaultColor;

        private void Start()
        {
            _defaultColor = _effectImage.color;
        }
        
        private void OnEnable()
        {
            _tapDetector.LongTouchContinue += IncreaseCircle;
            _tapDetector.LongTouchCanceled += DecreaseCirle;
            _slowStateToggler.SlowStateDisabled += DecreaseCirle;
        }

        private void IncreaseCircle()
        {
            if (!_slowStateToggler.CanActivate) return;
            
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _effectImage.transform.localScale = Vector3.zero;
                _coroutine = null;
            }

            _effectImage.color = _defaultColor;
            _effectImage.transform.position = new Vector3(_tapDetector.GetTapPosition().x, _tapDetector.GetTapPosition().y, 0);
            _effectImage.transform.localScale += _sizeToAdd;
            Handheld.Vibrate();
        }

        private void DecreaseCirle()
        {
            if (!_slowStateToggler.CanActivate) return;
            
            if (_coroutine != null) return;
            
            _coroutine = DecreaseCirlceWithDelay();
            StartCoroutine(_coroutine);
        }

        private IEnumerator DecreaseCirlceWithDelay()
        {
            while (_effectImage.transform.localScale.x > -0.1f)
            {
                _effectImage.transform.localScale -= _sizeToAdd;
                yield return new WaitForSecondsRealtime(0);
            }

            _effectImage.color = Color.clear;
            _coroutine = null;
        }

        private void OnDisable()
        {
            _tapDetector.LongTouchContinue -= IncreaseCircle;
            _tapDetector.LongTouchCanceled -= DecreaseCirle;
            _slowStateToggler.SlowStateDisabled -= DecreaseCirle;
        }
    }
}