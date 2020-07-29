using System;
using UnityEngine;

namespace PlayerInput
{
    [RequireComponent(typeof(TapDetector))]
    public class TapRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerToDetect;

        private TapDetector _detector;

        private void Awake()
        {
            _detector = GetComponent<TapDetector>();
        }

        private void OnEnable()
        {
            _detector.OnPlayerTap += DetectTap;
        }

        private void DetectTap()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _layerToDetect);
                if (hit.collider != null)
                    Debug.Log(hit.collider.name);
            }
        }

        private void OnDisable()
        {
            _detector.OnPlayerTap -= DetectTap;
        }
    }
}
