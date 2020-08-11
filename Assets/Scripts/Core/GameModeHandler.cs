using Interfaces;

namespace Core
{
    public class GameModeHandler : ILevelLoaderModeHandler
    {
        public GameModes CurrentGameMode { get; private set; }

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


    
   