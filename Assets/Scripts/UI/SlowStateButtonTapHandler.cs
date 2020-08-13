using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SlowStateButtonTapHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip _slowModeSound;
        [SerializeField] [Range(0f, 1f)] private float _slowModeSoundVolume;
            
        private void Awake()
        {
            
        }

        public void OnButtonTap()
        {
            PlaySound();
        }

        private void PlaySound()
        {
            AudioSource.PlayClipAtPoint(_slowModeSound, Camera.main.transform.position, _slowModeSoundVolume);
        }
    }
}