using UnityEngine;

namespace VFX
{
    [RequireComponent(typeof(TrailRenderer))]
    public class Trail : MonoBehaviour
    {
        private TrailRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<TrailRenderer>();
        }

        private void Update()
        {
            var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y, 0);
            
            if (!Input.GetMouseButton(0))
                _renderer.Clear();
        }
    }
}
