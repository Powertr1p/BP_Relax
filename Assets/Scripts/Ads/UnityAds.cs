using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public abstract class UnityAds : MonoBehaviour
    {
        protected const string GameID = "3805225";
        protected bool IsTestMode = false;

        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            Advertisement.Initialize(GameID, IsTestMode);
        }
    }
}