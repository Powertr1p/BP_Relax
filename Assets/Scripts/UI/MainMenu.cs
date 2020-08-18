using Core;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadGame()
        {
            LevelLoaderMode.Load("Game", GameMode.Relax);
        }
    }
}