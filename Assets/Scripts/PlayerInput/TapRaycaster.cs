using System;
using Interfaces;
using UnityEngine;

namespace PlayerInput
{
    [RequireComponent(typeof(TapDetector))]
    public class TapRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerToDetect;
        [SerializeField] private Camera _camera;

        public event Action<IPoppable> OnHitDetected;

        private TapDetector _detector;

        private void Awake()
        {
            _detector = GetComponent<TapDetector>();
        }

        private void OnEnable()
        {
            _detector.OnPlayerTap += TryDetectHit;
        }

        private void TryDetectHit()
        {
            var hit = Physics2D.RaycastAll(_camera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, _layerToDetect);

            foreach (var obj in hit)
            {
                if (obj.collider.TryGetComponent(out IPoppable bubble))
                    OnHitDetected?.Invoke(bubble);
            }
        }

        private void OnDisable()
        {
            _detector.OnPlayerTap -= TryDetectHit;
        }
    }
}
