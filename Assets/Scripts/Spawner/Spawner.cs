using System;
using System.Collections;
using Bubbles;
using Core;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    { 
        [SerializeField] private Factory _factory;

        [Header("Spawn Parameters")]
        [SerializeField] private float _minSpawnDelay = 0.1f;
        [SerializeField] private float _maxSpawnDelay = 0.5f;
        [SerializeField] private float _spawnRadius = 2f;
        
        [Header("SlowState Spawn Range(only Y) ")] 
        [SerializeField] private float _minSlowStateBottomYPosition = -1;
        [SerializeField] private float _maxSlowStateBottomYPosition = 2;
        [SerializeField] private float _minSlowStateTopYPosition = 11;
        [SerializeField] private float _maxSlowStateTopYPosition = 13;
        
        private void Start()
        {
            StartCoroutine(Spawn());
        }
        
         public void SpawnAdditionalBubblesForSlowState()
         {
             for (int i = 0; i < 20; i++)
             {
                 var bubble = _factory.GetCreatedBubble();
                 if (i <= 10)
                 {
                     bubble.transform.position = SetBubblePosition(_minSlowStateBottomYPosition, _maxSlowStateBottomYPosition);
                     bubble.GetComponent<Movement>().Speed = _factory.SpeedInSlowState;
                 }
                 else
                 {
                     bubble.transform.position = SetBubblePosition(_minSlowStateTopYPosition, _maxSlowStateTopYPosition);
                     bubble.GetComponent<Movement>().Speed = -_factory.SpeedInSlowState;
                 }
             }
         }
         
         private IEnumerator Spawn()
         { 
             while (true) 
             { 
                 var bubble = _factory.GetCreatedBubble(); 
                 bubble.transform.position = SetBubblePosition(0, 0);
                 
                 yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
             }
         }
         
         private Vector2 SetBubblePosition(float minYPosition, float maxYPosition)
         {
             return transform.position + new Vector3(Random.Range(-_spawnRadius, _spawnRadius), Random.Range(minYPosition, maxYPosition));
         }
    }
}
