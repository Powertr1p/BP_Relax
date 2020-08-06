using UnityEngine;

namespace VFX
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _delayBeforeDestroy = 0.4f;
        
        private void Start()
        {
            Destroy(gameObject, _delayBeforeDestroy);
        }
    }
}
