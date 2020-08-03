using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class Bubble : MonoBehaviour, IPoppable
    {
        private Camera _camera;
        
        private void Update()
        {
            if (!IsOnScreen())
                Destroy(gameObject);
        }

        public void Init(Camera camera)
        {
            _camera = camera;
        }
        
        public void Pop()
        {
            Destroy(gameObject);
        }

        private bool IsOnScreen()
        {
            Vector2 screenPoint = _camera.WorldToViewportPoint(transform.position);
            bool isOnScreen = screenPoint.y < 1.1f;
            return isOnScreen;
        }
    }
}