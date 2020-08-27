using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class BannerAds : UnityAds
    {
        private const string _placementID = "BannerPlacement";

        protected override void Init()
        {
            base.Init();
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }
        
        public static IEnumerator ShowBanner()
        {
            while (!Advertisement.isInitialized)
                yield return new WaitForSecondsRealtime(0.1f);

            Advertisement.Banner.Show(_placementID);
        }
    }
}