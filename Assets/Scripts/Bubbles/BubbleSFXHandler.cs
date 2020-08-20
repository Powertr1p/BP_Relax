using Bubbles.Abstract;
using UnityEngine;

namespace Bubbles
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Bubble))]
    public class BubbleSFXHandler : MonoBehaviour
    {
        private AudioSource _audio;
        private Bubble _bubble;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            _bubble = GetComponent<Bubble>();
        }

        private void OnEnable()
        {
            _bubble.Poped += OnPop;
        }

        private void OnPop()
        {
            _audio.Play();
        }

        private void OnDisable()
        {
            _bubble.Poped -= OnPop;
        }
    }
}