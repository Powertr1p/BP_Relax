using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class Bubble : MonoBehaviour, IPoppable
    {
        public void Pop()
        {
            Destroy(gameObject);
        }
    }
}