using PlayerInput;
using SlowMode;
using UnityEngine;

namespace VFX
{
    public class SwipeTrailVFXSpawer : MonoBehaviour
    {
        [SerializeField] private Trail _trailPrefab;
        [SerializeField] private SlowStateToggler _slowStateToggler;
        [SerializeField] private TapDetector _tapDetector;
        
        private Trail _activeTrail;
        
        private void OnEnable()
        {
            _slowStateToggler.SlowStateEnabled += SpawnTrail;
            _slowStateToggler.SlowStateDisabled += DestroyTrail;
        }

        private void SpawnTrail()
        {
            if (_activeTrail != null) return;
            
            var trail = Instantiate(_trailPrefab, _tapDetector.GetTapPosition(), Quaternion.identity);
            trail.Init(_tapDetector);
            _activeTrail = trail;
        }

        private void DestroyTrail()
        {
            Destroy(_activeTrail.gameObject);
            _activeTrail = null;
        }

        private void OnDisable()
        {
            _slowStateToggler.SlowStateEnabled -= SpawnTrail;
            _slowStateToggler.SlowStateDisabled -= DestroyTrail;
        }
    }
}