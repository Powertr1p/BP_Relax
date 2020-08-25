using System;
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

        private void OnEnable()
        {
            _tapDetector.LongTouchContinue += IncreaseCircle;
            _tapDetector.LongTouchCanceled += DecreaseCirle;
            _slowStateToggler.SlowStateDisabled += DecreaseCirle;
        }

        private void IncreaseCircle()
        {
            _effectImage.transform.position = new Vector3(_tapDetector.GetTapPosition().x, _tapDetector.GetTapPosition().y, 0);
            _effectImage.transform.localScale += new Vector3(0.3f,0.3f,0);
        }

        private void DecreaseCirle()
        {
            _effectImage.transform.localScale = new Vector3(0,0,0);
        }

        private void OnDisable()
        {
            _tapDetector.LongTouchContinue -= IncreaseCircle;
            _tapDetector.LongTouchCanceled -= DecreaseCirle;
            _slowStateToggler.SlowStateDisabled -= DecreaseCirle;
        }
    }
}