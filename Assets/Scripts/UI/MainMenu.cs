using Core;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadRelaxMode()
        {
            LevelLoaderMode.Load("Game", GameMode.Relax);
        }

        public void LoadArcadeMode()
        {
            LevelLoaderMode.Load("Game", GameMode.Arcade);
        }
    }
}