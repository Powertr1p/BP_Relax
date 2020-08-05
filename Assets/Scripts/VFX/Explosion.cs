using UnityEngine;

namespace VFX
{
    public class Explosion : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 0.4f);
        }
    }
}
