using SlowMode;
using UnityEngine;

namespace UI
{
    public class SlowStateSFXHandler : MonoBehaviour
    {
        [SerializeField] private SlowStateToggler _slowStateToggler;
        [SerializeField] private AudioClip _slowModeSound;
        [SerializeField] [Range(0f, 1f)] private float _slowModeSoundVolume;

        private void OnEnable()
        {
            _slowStateToggler.SlowStateEnabled += PlaySound;
        }

        private void PlaySound()
        {
            AudioSource.PlayClipAtPoint(_slowModeSound, Camera.main.transform.position, _slowModeSoundVolume);
        }

        private void OnDisable()
        {
            _slowStateToggler.SlowStateEnabled -= PlaySound;
        }
    }
}