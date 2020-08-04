using UnityEngine;

namespace Bubbles
{
    public class Movement : MonoBehaviour
    {
        public float _speed;
        private float _magnitude;
        private float _frequency;

        private Vector3 _position;

        private void Start()
        {
            _position = transform.position;
            GetRandomAttrubutes();
        }

        private void Update()
        {
            MoveUp();
        }

        private void MoveUp()
        {
            _position += Vector3.up * (Time.deltaTime * _speed);
            transform.position = _position + Vector3.right * (Mathf.Sin(Time.time * _frequency) * _magnitude);
        }

        private void GetRandomAttrubutes()
        {
            var randomScale = Random.Range(0.3f, 2.5f);
            transform.localScale = new Vector3(randomScale, randomScale);
            
            _frequency = Random.Range(0.2f, 1.5f);
            _speed = Random.Range(0.3f, 1f);
            _magnitude = Random.Range(0.5f, 1.5f);
        }
    }
}