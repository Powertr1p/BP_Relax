using Bubbles.Abstract;
using UnityEngine;

namespace Bubbles
{
    public class DefaultBubble : Bubble
    {
        [SerializeField] private int _score = 1;
        public override int GetScore()
        {
            return _score;
        }
    }
}