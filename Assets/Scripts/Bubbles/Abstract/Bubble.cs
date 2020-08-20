using System;
using System.Collections;
using Core;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

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
        private GameOverHandler _handler;
        
        private Vector2 _screenPoint;
        
        private static readonly int PopAnimation = Animator.StringToHash("Pop");

        public abstract int GetScore();
        
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

        public virtual void Init(Camera camera, GameOverHandler handler)
        {
            _camera = camera;
            _handler = handler;
            _handler.OnGameOver += OnGameOver;
        }
        
        public virtual void Pop()
        {
            _collider.enabled = false;
            _animator.SetTrigger(PopAnimation);
            _audio.Play();
        }

        private void OnGameOver()
        {
            StartCoroutine(WaitBeforePop());
        }
        
        private IEnumerator WaitBeforePop()
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 2f));
            _audio.volume = 0.1f;
            Pop();
        }

        private void DestroyObjectOnPopAnimationEnds()
        {
            Destroy(gameObject);
        }

        private bool IsOnScreen()
        {
            _screenPoint = _camera.WorldToViewportPoint(transform.position);
            return _screenPoint.y < 1.1f && _screenPoint.y > -1.1f;
        }

        private void OnDisable()
        {
            _handler.OnGameOver -= OnGameOver;
        }
    }
}