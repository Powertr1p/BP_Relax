using UnityEngine;

namespace Bubbles
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _magnitude = 0.5f;
        [SerializeField] private float _frequency = 1f;

        private Vector3 position;

        private void Start()
        {
            position = transform.position;
        }

        private void Update()
        {
            MoveUp();
        }

        private void MoveUp()
        {
            position += Vector3.up * (Time.deltaTime * _speed);
            transform.position = position + Vector3.right * (Mathf.Sin(Time.time * _frequency) * _magnitude);
        }
    }
}
