using System;
using Interfaces;
using UnityEngine;

namespace PlayerInput
{
    [RequireComponent(typeof(TapRaycaster))]
    public class OnBubbleHitHandler : MonoBehaviour
    {
        [SerializeField] private TapRaycaster _raycaster;
        
        private void OnEnable()
        {
            _raycaster.OnHitDetected += OnBubbleTap;
        }

        private void OnBubbleTap(IPoppable bubble)
        {
            bubble.Pop();
        }
    }
}
