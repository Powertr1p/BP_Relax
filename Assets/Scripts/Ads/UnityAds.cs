using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public abstract class UnityAds : MonoBehaviour
    {
        public event Action OnAdsInitialized;
        
        protected const string GameID = "3805225";
        protected bool IsTestMode = false;

        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            Advertisement.Initialize(GameID, IsTestMode);
            StartCoroutine(WaitForAdsInit());
        }

        private IEnumerator WaitForAdsInit()
        {
            float count = 0f;
            while (!Advertisement.isInitialized)
            {
                yield return new WaitForSeconds(0.1f);
                count += 0.1f;

                if (count >= 5f)
                    break;
            }

            OnAdsInitialized?.Invoke();
        }
    }
}