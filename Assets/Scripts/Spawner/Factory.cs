using System;
using System.Collections.Generic;
using Bubbles;
using Bubbles.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
   public class Factory : MonoBehaviour
   {
      [SerializeField] private Camera _camera;
      [SerializeField] private DefaultBubble _defaultBubblePrefab;
      [SerializeField] private BombBubble _bombBubblePrefab;
      [SerializeField] private int _chanceToCreateBombBubble = 10;

      public Bubble GetCreatedBubble()
      {
         var bubble = CreateBubble();
         bubble.Init(_camera);

         return bubble;
      }

      private Bubble CreateBubble()
      {
         return Random.Range(0, 100) <= _chanceToCreateBombBubble ? CreateBombBubble() : CreateDefaultBubble();
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
   }
}
