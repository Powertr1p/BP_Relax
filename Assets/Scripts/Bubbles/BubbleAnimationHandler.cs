using System;
using Bubbles.Abstract;
using UnityEngine;

namespace Bubbles
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Bubble))]
    public class BubbleAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private Bubble _bubble;

        private static readonly int PopAnimation = Animator.StringToHash("Pop");
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _bubble = GetComponent<Bubble>();
        }

        private void OnEnable()
        {
            _bubble.Poped += OnPop;
        }

        private void OnPop()
        {
            _animator.SetTrigger(PopAnimation);
        }

        private void DestroyObjectOnPopAnimationEnds()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            _bubble.Poped -= OnPop;
        }
    }
}
