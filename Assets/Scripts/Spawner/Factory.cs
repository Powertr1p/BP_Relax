using System.Collections;
using Bubbles;
using Bubbles.Abstract;
using Core;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
   public class Factory : MonoBehaviour, ILevelLoaderModeHandler
   {
      [SerializeField] private Camera _camera;
      [SerializeField] private DefaultBubble _defaultBubblePrefab;
      [SerializeField] private BombBubble _bombBubblePrefab;
      [SerializeField] private int _chanceToCreateBombBubble = 10;
      [SerializeField] private FruitBubble _fruitBubblePrefab;
      [SerializeField] private int _chanceToCreateFruitBubble = 25;
      [SerializeField] private float _speedMultiplier = 0.2f;

      private GameMode _gameMode;

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
         if (_gameMode == GameMode.Relax) return CreateDefaultBubble();
         
         var roll = Random.Range(0, 100);
         if (roll <= _chanceToCreateBombBubble)
            return CreateBombBubble();
         
         if (roll >= _chanceToCreateBombBubble && roll <= _chanceToCreateFruitBubble)
            return CreateFruitBubble();
         
         return CreateDefaultBubble();
      }

      private Bubble CreateDefaultBubble()
      {
         var createdBubble = Instantiate(_defaultBubblePrefab, Vector3.zero, Quaternion.identity);

         return createdBubble;
      }

      private Bubble CreateBombBubble()
      {
         var createdBubble = Instantiate(_bombBubblePrefab, Vector3.zero, Quaternion.identity);

         return createdBubble;
      }

      private Bubble CreateFruitBubble()
      {
         var createdBubble = Instantiate(_fruitBubblePrefab, Vector3.zero, Quaternion.identity);
         var fruit = createdBubble.GetComponentInChildren<Fruit>();
         fruit.SetCamera(_camera);
         
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
         yield return new WaitForSeconds(2f);
         _speedMultiplier *= 2;
      }

      public void OnLevelLoad(GameMode mode)
      {
         _gameMode = mode;
      }
   }
}
