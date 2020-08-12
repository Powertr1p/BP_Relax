using System;
using Bubbles.Abstract;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Bubbles
{
    public class BombBubble : Bubble
    {
        [SerializeField] private GameObject _explosion;
        [SerializeField] private int _score = -50;
        [SerializeField] private LayerMask _layerMask;

        public override void Pop()
        {
            var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            explosion.transform.localScale = transform.localScale * 3;

            PopNearbyBubbles();
            Destroy(gameObject);
        }

        private void PopNearbyBubbles()
        {
            var overlapedBubbles = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x, _layerMask);
            if (overlapedBubbles.Length > 0)
            {
                foreach (var bubble in overlapedBubbles)
                    if (bubble.transform.root != transform)
                        bubble.GetComponent<IPoppable>().Pop();
            }
        }

        public override int GetScore()
        {
            return _score;
        }
    }
}