using Interfaces;

namespace Core
{
    public class GameMode : ILevelLoaderModeHandler
    {
        public static GameModes GetGameMode { get; private set; }

        public static void SetGameMode(GameModes mode)
        {
            GetGameMode = mode;
        }
        
        public enum GameModes
        {
            Relax,
            Arcade
        }
        
        public void OnLevelLoad(GameModes mode)
        {
            SetGameMode(mode);
        }
    }
}
    
   