using System;
using UnityEngine;

namespace PlayerInput
{
    public class TapDetector : MonoBehaviour
    {
        public event Action OnPlayerTap;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnPlayerTap?.Invoke();
            }
        }
    }
}
