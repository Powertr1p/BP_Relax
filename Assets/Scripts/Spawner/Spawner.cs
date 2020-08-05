using System.Collections;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private float _minSpawnDelay = 0.3f;
        [SerializeField] private float _maxSpawnDelay = 0.7f;
        [SerializeField] private float _spawnRadius = 2f;

        private void Start()
        {
            StartCoroutine(Spawn());
        }
    
         private IEnumerator Spawn()
         {
              while (true)
              {
                  var bubble = _factory.GetCreatedBubble();
                  bubble.transform.position = transform.position + new Vector3(Random.Range(-_spawnRadius, _spawnRadius), 0);

                  yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
             }
         }
    }
}
