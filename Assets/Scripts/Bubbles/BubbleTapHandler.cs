using System;
using UnityEngine;

namespace Bubbles
{
    public class BubbleTapHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerToDetect;
        
        private void Update()
        {
            DetectTap();
        }

        private void DetectTap()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _layerToDetect);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                }

            }
        }
    }
}
