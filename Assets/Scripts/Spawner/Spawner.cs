using System.Collections;
using Bubbles.Abstract;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _bubblePrefab;
        [SerializeField] private Camera _camera;

        private void Start()
        {
            StartCoroutine(Spawn());
        }
    
        private IEnumerator Spawn()
        {
            while (true)
            {
                var obj = Instantiate(_bubblePrefab, transform.position + new Vector3(Random.Range(-2.2f, 2.3f), 0), Quaternion.identity);
                if (obj.TryGetComponent(out Bubble bubble))
                    bubble.Init(_camera);
            
                yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
            }
        }
    }
}
