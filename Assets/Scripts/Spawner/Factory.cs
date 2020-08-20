using System.Collections;
using Bubbles;
using Bubbles.Abstract;
using Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
   public class Factory : MonoBehaviour
   {
      [Header("Core")]
      [SerializeField] private Camera _camera;
      [SerializeField] private DefaultBubble _defaultBubblePrefab;
      [SerializeField] private GameOverHandler _gameOverHandler;
      [SerializeField] private float _speedMultiplier = 0.2f;
      [SerializeField] private float _delayBeforeSpeedUp = 2.5f;

      [Header("Bubble Parameters")] 
      [SerializeField] private float _minSpeed = 0.3f;
      [SerializeField] private float _maxSpeed = 1.5f;
      
      [Space(5f)] 
      [SerializeField] private float _minFrequency = 0.2f;
      [SerializeField] private float _maxFrequency = 1.5f;
      
      [Space(5f)] 
      [SerializeField] private float _minMagnitude = 0.5f;
      [SerializeField] private float _maxMagnitude = 1.1f;

      [Space(5f)] 
      [SerializeField] private float _minScale = 0.7f;
      [SerializeField] private float _maxScale = 2.5f;

      [Space(5f)] 
      [SerializeField] private float _speedInSlowState = 4f;

      public float SpeedInSlowState => _speedInSlowState;

      private void Start()
      {
         StartCoroutine(IncreaseSpeedMultiplier());
      }
      
      public Bubble GetCreatedBubble()
      {
         var bubble = CreateBubble();
         
         bubble.Init(_camera, _gameOverHandler);
         SetRandomAttributes(bubble);
         
         return bubble;
      }

      private Bubble CreateBubble()
      {
         var createdBubble = Instantiate(_defaultBubblePrefab, Vector3.zero, Quaternion.identity);

         return createdBubble;
      }

      private void SetRandomAttributes(Bubble bubble)
      {
         var randomScale = Random.Range(_minScale, _maxScale);
         bubble.transform.localScale = new Vector3(randomScale, randomScale);

         if (bubble.TryGetComponent(out Movement movement))
         {
            movement.Speed = Random.Range(_minSpeed, _maxSpeed) + _speedMultiplier;
            movement.Frequency = Random.Range(_minFrequency, _maxFrequency);
            movement.Magnitude = Random.Range(_minMagnitude, _maxMagnitude);
         }
      }

      private IEnumerator IncreaseSpeedMultiplier()
      {
         while (true)
         {
            yield return new WaitForSeconds(_delayBeforeSpeedUp);
            _speedMultiplier += 0.1f;
         }
      }
   }
}
