using System.Collections;
using Bubbles;
using Bubbles.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
   public class Factory : MonoBehaviour
   {
      [Header("Core")]
      [SerializeField] private Camera _camera;
      [SerializeField] private DefaultBubble _defaultBubblePrefab;
      [SerializeField] private float _speedMultiplier = 0.2f;
      [SerializeField] private float _delayBeforeSpeedUp = 2.5f;

      private void Start()
      {
         StartCoroutine(IncreaseSpeedMultiplier());
      }
      
      public Bubble GetCreatedBubble()
      {
         var bubble = CreateBubble();
         
         bubble.Init(_camera);
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
         var randomScale = Random.Range(0.7f, 2.5f);
         bubble.transform.localScale = new Vector3(randomScale, randomScale);

         if (bubble.TryGetComponent(out Movement movement))
         {
            movement.Speed = Random.Range(0.3f, 1.5f) + _speedMultiplier;
            movement.Frequency = Random.Range(0.2f, 1.5f);
            movement.Magnitude = Random.Range(0.5f, 1.1f);
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
