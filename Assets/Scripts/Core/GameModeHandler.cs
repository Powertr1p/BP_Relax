using Interfaces;
using UnityEngine;

namespace Core
{
    public class GameModeHandler : MonoBehaviour, ILevelLoaderModeHandler
    {
        public static GameModes CurrentGameMode { get; private set; }

        public void OnLevelLoad(GameModes mode)
        {
            CurrentGameMode = mode;
        }
    }
    
    public enum GameModes
    {
        Relax, 
        Arcade
    }
}


    
   