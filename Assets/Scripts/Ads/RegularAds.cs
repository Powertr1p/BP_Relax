using System;
using UnityEngine.Advertisements;

namespace Ads
{
    public class RegularAds : UnityAds
    {
        private const string _placementID = "video";
        
        public static void ShowAds()
        {
            if (Advertisement.IsReady(_placementID))
                Advertisement.Show(_placementID);
        }
    }
}