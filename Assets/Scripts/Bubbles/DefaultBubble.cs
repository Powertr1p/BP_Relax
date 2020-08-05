using Bubbles.Abstract;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class DefaultBubble : Bubble, IScoreable
    {
        [SerializeField] private int _score = 1;
        
        public int GetScore()
        {
            return _score;
        }
    }
}