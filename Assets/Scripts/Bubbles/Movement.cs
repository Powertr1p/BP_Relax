using UnityEngine;

namespace Bubbles
{
    public class Movement : MonoBehaviour
    {
        private float _speed;
        private float _magnitude;
        private float _frequency;

        private Vector3 position;

        private void Start()
        {
            position = transform.position;
            GetRandomAttrubutes();
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

        private void GetRandomAttrubutes()
        {
            _frequency = Random.Range(0.2f, 1.5f);
            _speed = Random.Range(0.5f, 1f);
            _magnitude = Random.Range(0.5f, 1.5f);
        }
    }
}
