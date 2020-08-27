using System;
using Ads;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(BannerAds.ShowBanner());
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}