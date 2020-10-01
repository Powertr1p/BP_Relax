using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public abstract class UnityAds : MonoBehaviour
    {
        private const string GameID = "3805225";
        private bool _isTestMode = false;

        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            Advertisement.Initialize(GameID, _isTestMode);
        }
    }
}