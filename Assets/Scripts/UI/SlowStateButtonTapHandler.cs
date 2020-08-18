using System.Collections;
using UnityEngine;

namespace UI
{
    public class SlowStateButtonTapHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip _slowModeSound;
        [SerializeField] [Range(0f, 1f)] private float _slowModeSoundVolume;

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