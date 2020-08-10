using Core;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadRelaxMode()
        {
            LevelLoaderMode.Load("Game", GameMode.GameModes.Relax);
        }

        public void LoadArcadeMode()
        {
            LevelLoaderMode.Load("Game", GameMode.GameModes.Arcade);
        }
    }
}