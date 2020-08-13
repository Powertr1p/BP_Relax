using System;
using SlowMode;
using UnityEngine;

namespace VFX
{
    public class SwipeTrailVFX : MonoBehaviour
    {
        [SerializeField] private Trail _trail;
        [SerializeField] private SlowStateToggler _slowStateToggler;

        private void OnEnable()
        {
            
        }

        private void SpawnTrail()
        {
            var trail = Instantiate(_trail, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }
}