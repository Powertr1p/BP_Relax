using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class Bubble : MonoBehaviour, IPoppable
    {
        [SerializeField] private Camera _camera;
        
        private void Update()
        {
            if (!IsBubbleOnScreen())
                Destroy(gameObject);
        }

        public void Pop()
        {
            Destroy(gameObject);
        }

        private bool IsBubbleOnScreen()
        {
            Vector2 screenPoint = _camera.WorldToViewportPoint(transform.position);
            bool isOnScreen = screenPoint.y < 1.1f;
            return isOnScreen;
        }
    }
}