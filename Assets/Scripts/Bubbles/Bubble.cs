using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public abstract class Bubble : MonoBehaviour, IPoppable
    {
        private Camera _camera;
        private Animator _animator;
        private AudioSource _audio;

        private Vector2 _screenPoint;
        
        private static readonly int PopAnimation = Animator.StringToHash("Pop");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
        }
        
        private void Update()
        {
            if (!IsOnScreen())
                Destroy(gameObject);
        }

        public virtual void Init(Camera camera)
        {
            _camera = camera;
        }
        
        public virtual void Pop()
        {
            _animator.SetTrigger(PopAnimation);
            _audio.Play();
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