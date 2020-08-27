using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public abstract class UnityAds : MonoBehaviour
    {
        protected const string GameID = "3791255";
        protected bool IsTestMode = true;

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