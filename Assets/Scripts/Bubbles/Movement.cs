using UnityEngine;

namespace Bubbles
{
    public class Movement : MonoBehaviour
    {
        public float Speed;
        public float Magnitude;
        public float Frequency;

        private Vector3 _position;

        private void Start()
        {
            _position = transform.position;
        }

        private void Update()
        {
            MoveUp();
        }

        private void MoveUp()
        {
            _position += Vector3.up * (Time.deltaTime * Speed);
            transform.position = _position + Vector3.right * (Mathf.Sin(Time.time * Frequency) * Magnitude);
        }
    }
}