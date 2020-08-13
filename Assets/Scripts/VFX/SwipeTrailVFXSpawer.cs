using SlowMode;
using UnityEngine;

namespace VFX
{
    public class SwipeTrailVFXSpawer : MonoBehaviour
    {
        [SerializeField] private Trail _trail;
        [SerializeField] private SlowStateToggler _slowStateToggler;

        private Trail _activeTrail;
        
        private void OnEnable()
        {
            _slowStateToggler.SlowStateEnabled += SpawnTrail;
            _slowStateToggler.SlowStateDisabled += DestroyTrail;
        }

        private void SpawnTrail()
        {
            if (_activeTrail != null) return;
            
            var trail = Instantiate(_trail, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
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