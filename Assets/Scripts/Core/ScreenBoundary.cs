using System;
using UnityEngine;

namespace Core
{
    public class ScreenBoundary : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private readonly float _offScreenDelta = 2f;

        public float GetTopBoundariesPosition()
        {
             Vector3 screenSize = new Vector3(_camera.pixelWidth, _camera.pixelHeight);
             return _camera.ScreenToWorldPoint(screenSize).y + _offScreenDelta;
        }

        public float GetBottomBoundariesPosition()
        {
            return _camera.ScreenToWorldPoint(Vector3.zero).y - _offScreenDelta;
        }
    }
}