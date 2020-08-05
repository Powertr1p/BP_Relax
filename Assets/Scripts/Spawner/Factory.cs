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
         Func<Bubble>[] creators = { CreateDefaultBubble, CreateBombBubble };
         var creator = GetCreator(creators);
         var bubble = creator();
         bubble.Init(_camera);

         return bubble;
      }

      private Func<Bubble> GetCreator(IReadOnlyList<Func<Bubble>> creators)
      {
         return Random.Range(0, 100) <= _chanceToCreateBombBubble ? creators[1] : creators[0];
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
