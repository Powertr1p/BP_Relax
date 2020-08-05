using Bubbles.Abstract;
using UnityEngine;

namespace Bubbles
{
    public class BombBubble : Bubble
    {
        [SerializeField] private GameObject _explosion;

        public override void Pop()
        {
            var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            explosion.transform.localScale = transform.localScale * 2;
            
            Destroy(gameObject);
        }

        protected override void Update() //delete this on tests
        {
            
        }
    }
}