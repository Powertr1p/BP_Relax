using System.Collections;
using Bubbles;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private float _minSpawnDelay = 0.1f;
        [SerializeField] private float _maxSpawnDelay = 0.5f;
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

         public void SpawnAdditionalBubblesForSlowState()
         {
             var speed = 4f;
             for (int i = 0; i < 10; i++)
             {
                 var bubble = _factory.GetCreatedBubble();
                 bubble.transform.position = transform.position + new Vector3(Random.Range(-_spawnRadius, _spawnRadius), Random.Range(-1,2));
                 bubble.GetComponent<Movement>().Speed = speed;
             }

             for (int i = 0; i < 10; i++)
             {
                 var bubble = _factory.GetCreatedBubble();
                 bubble.transform.position = transform.position + new Vector3(Random.Range(-_spawnRadius, _spawnRadius), Random.Range(11,13));
                 bubble.GetComponent<Movement>().Speed = -speed;
             }
         }
    }
}
