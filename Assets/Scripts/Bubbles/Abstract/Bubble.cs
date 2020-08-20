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
    public abstract class Bubble : MonoBehaviour, IPoppable
    {
        public event Action Poped;
        
        private AudioSource _audio;
        private Collider2D _collider;
        private GameOverHandler _handler;
        
        private float _maxScreenPosition;
        private float _minScreenPosition;

        public abstract int GetScore();

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _collider = GetComponent<Collider2D>();
        }
        
        protected virtual void Update()
        {
            if (!IsOnScreen())
                Destroy(gameObject);
        }

        public virtual void Init(float maxPossiblePosition, float minPossiblePosition, GameOverHandler handler)
        {
            _maxScreenPosition = maxPossiblePosition;
            _minScreenPosition = minPossiblePosition;
            _handler = handler;
            _handler.OnGameOver += OnGameOver;
        }
        
        public virtual void Pop()
        {
            _collider.enabled = false;
            Poped?.Invoke();
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

        private bool IsOnScreen()
        {
            var currentPosition = transform.position.y;
            return currentPosition < _maxScreenPosition && currentPosition > _minScreenPosition;
        }

        private void OnDisable()
        {
            _handler.OnGameOver -= OnGameOver;
        }
    }
}