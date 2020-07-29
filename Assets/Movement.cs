using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _magnitude = 0.5f;
        [SerializeField] private float _frequency = 20f;

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
            position += transform.up * (Time.deltaTime * _speed);
            transform.position = position + transform.right * (Mathf.Sin(Time.time * _frequency) * _magnitude);
        }
    }
}
