using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Fruit : MonoBehaviour, IPoppable
    {
        [SerializeField] private int _score = 20;
        
        private Collider2D _collider2D;
        private Rigidbody2D _rigidbody;
        private FruitBubble _bubble;
        private Camera _camera;

        private Vector3 _screenPoint;
        
        private void Awake()
        {
            _bubble = GetComponentInParent<FruitBubble>();
            _collider2D = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
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
        }

        private void StartFalling()
        {
             transform.parent = null;
            _collider2D.enabled = true;
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
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
        }
    }
}