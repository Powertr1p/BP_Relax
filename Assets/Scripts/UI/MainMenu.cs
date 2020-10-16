using Ads;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _creditsPanel;
        
        private bool _isCreditsOpen;

        public void ShowCredits()
        {
            _creditsPanel.SetActive(!_isCreditsOpen);
            _isCreditsOpen = !_isCreditsOpen;
        }
        
        public void LoadGame()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}