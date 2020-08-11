using Core;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadRelaxMode()
        {
            LevelLoaderMode.Load("Game", GameModes.Relax);
        }

        public void LoadArcadeMode()
        {
            LevelLoaderMode.Load("Game", GameModes.Arcade);
        }
    }
}