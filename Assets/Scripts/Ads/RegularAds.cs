using UnityEngine.Advertisements;

namespace Ads
{
    public class RegularAds : UnityAds
    {
        private const string PlacementID = "video";
        
        public static void ShowAds()
        {
            Advertisement.Show(PlacementID);
        }
    }
}