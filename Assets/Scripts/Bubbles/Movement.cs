using UnityEngine;

namespace Bubbles
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speedMultiplier = 0.001f;
        
        private float _speed;
        private float _magnitude;
        private float _frequency;

        private Vector3 position;

        private void Start()
        {
            position = transform.position;
            GetRandomAttrubutes();
            var randomScale = Random.Range(1f, 2.5f);
            transform.localScale = new Vector3(randomScale, randomScale);
        }

        private void Update()
        {
            MoveUp();
        }

        private void MoveUp()
        {
            position += Vector3.up * (Time.deltaTime * _speed);
            transform.position = position + Vector3.right * (Mathf.Sin(Time.time * _frequency) * _magnitude);
            _speed += _speedMultiplier;
        }

        private void GetRandomAttrubutes()
        {
            _frequency = Random.Range(0.2f, 1.5f);
            _speed = Random.Range(0.5f, 1f);
            _magnitude = Random.Range(0.5f, 1.5f);
        }
    }
}