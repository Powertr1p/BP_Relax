using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class Bubble : MonoBehaviour, IPoppable
    {
        private Camera _camera;
        private Animator _animator;

        private Vector2 _screenPoint;
        private static readonly int PopAnimation = Animator.StringToHash("Pop");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
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
            _animator.SetTrigger(PopAnimation);
        }

        private void DestroyObjectOnPopAnimationEnds()
        {
            Destroy(gameObject);
        }

        private bool IsOnScreen()
        {
            _screenPoint = _camera.WorldToViewportPoint(transform.position);
            return _screenPoint.y < 1.1f;
        }
    }
}