using System;
using Interfaces;
using UnityEngine;

namespace PlayerInput
{
    public class OnBubbleHitHandler : MonoBehaviour
    {
        [SerializeField] private TapRaycaster _raycaster;

        public event Action OnBubblePopped;
        
        private void OnEnable()
        {
            _raycaster.OnHitDetected += OnBubbleTap;
        }

        private void OnBubbleTap(IPoppable bubble)
        {
            bubble.Pop();
            OnBubblePopped?.Invoke();
        }

        private void OnDisable()
        {
            _raycaster.OnHitDetected -= OnBubbleTap;
        }
    }
}
