using PlayerInput;
using UnityEngine;

namespace VFX
{
    [RequireComponent(typeof(TrailRenderer))]
    public class Trail : MonoBehaviour
    { 
        private TrailRenderer _renderer;
        private TapDetector _tapDetector;
        
        
        private void Awake()
        {
            _renderer = GetComponent<TrailRenderer>();
        }

        public void Init(TapDetector tapDetector)
        {
            _tapDetector = tapDetector;
        }

        private void Update()
        {
            transform.position = new Vector3(_tapDetector.GetTapPosition().x, _tapDetector.GetTapPosition().y, 0);
            
            if (!Input.GetMouseButton(0)) //TODO: delete before build
                _renderer.Clear();
        }
    }
}
