using System.Collections;
using AppodealAds.Unity.Api;
using UnityEngine;

namespace Ads
{
    public class Ads : MonoBehaviour
    {
        private const string AppKey = "50adf1be2716c77b3ffe8b1e3f6422280a83ef3305636d81";
        
        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            Appodeal.initialize(AppKey,Appodeal.INTERSTITIAL);
            Appodeal.muteVideosIfCallsMuted(true);
        }
    }
}