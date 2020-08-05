using Interfaces;
using UnityEngine;

namespace Bubbles.Abstract
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animator))]
    public abstract class Bubble : MonoBehaviour, IPoppable
    {
        private Camera _camera;
        private Animator _animator;
        private AudioSource _audio;
        private Collider2D _collider;
        
        private Vector2 _screenPoint;
        
        private static readonly int PopAnimation = Animator.StringToHash("Pop");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
            _collider = GetComponent<Collider2D>();
        }
        
        protected virtual void Update()
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
            _collider.enabled = false;
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