using UnityEngine;

namespace Bubbles
{
    public class BombBubble : Bubble
    {
        public override void Pop()
        {
            Debug.Log("BOOM");
        }
    }
}