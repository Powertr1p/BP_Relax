using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Fruit : MonoBehaviour, IPoppable
    {
        [SerializeField] private int _score = 20;
        
        private Collider2D _collider2D;
        private Rigidbody2D _rigidbody;
        private FruitBubble _bubble;
        private Camera _camera;
        private Animator _animator;

        private Vector3 _screenPoint;

        private static readonly int Animation = Animator.StringToHash("StartAnimation");

        private void Awake()
        {
            _bubble = GetComponentInParent<FruitBubble>();
            _collider2D = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!IsOnScreen())
                Destroy(gameObject);
        }

        public void SetCamera(Camera camera)
        {
            _camera = camera;
        }
        
        private void OnEnable()
        {
            _bubble.OnBubblePopped += StartFalling;
            _bubble.OnBubblePopped += StartAnimation;
        }

        private void StartFalling()
        {
             transform.parent = null;
            _collider2D.enabled = true;
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }

        private void StartAnimation()
        {
            _animator.SetTrigger(Animation);
        }
        
        private bool IsOnScreen()
        {
            _screenPoint = _camera.WorldToViewportPoint(transform.position);
            return _screenPoint.y > -0.5f;
        }

        public void Pop()
        {
            Destroy(gameObject);
        }

        public int GetScore()
        {
            return _score;
        }
        
        private void OnDisable()
        {
            _bubble.OnBubblePopped -= StartFalling;
            _bubble.OnBubblePopped -= StartAnimation;
        }
    }
}