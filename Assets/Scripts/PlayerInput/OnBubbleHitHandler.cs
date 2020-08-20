using System;
using Interfaces;
using UnityEngine;

namespace PlayerInput
{
    public class OnBubbleHitHandler : MonoBehaviour
    {
        [SerializeField] private TapRaycaster _raycaster;

        public event Action<int> OnBubblePoped;
        
        private void OnEnable()
        {
            _raycaster.OnHitDetected += OnBubbleTap;
        }

        private void OnBubbleTap(IPoppable bubble)
        {
            bubble.Pop();
            OnBubblePoped?.Invoke(bubble.GetScore());
        }

        private void OnDisable()
        {
            _raycaster.OnHitDetected -= OnBubbleTap;
        }
    }
}
