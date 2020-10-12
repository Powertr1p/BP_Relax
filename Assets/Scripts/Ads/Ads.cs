using AppodealAds.Unity.Api;
using UnityEngine;

namespace Ads
{
    public class Ads : MonoBehaviour
    {
        private const string AppKey = "";
        
        private void Start()
        {
            Appodeal.setTesting(true);
            Appodeal.initialize(AppKey,Appodeal.INTERSTITIAL);
        }
    }
}