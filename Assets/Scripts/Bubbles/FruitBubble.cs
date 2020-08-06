using System;
using Bubbles.Abstract;
using UnityEngine;

namespace Bubbles
{
    public class FruitBubble : Bubble
    {
        [SerializeField] private int _score = 1;
        
        public event Action OnBubblePopped;

        public override int GetScore()
        {
            return _score;
        }

        public override void Pop()
        {
            base.Pop();
            OnBubblePopped?.Invoke();
        }
    }
}