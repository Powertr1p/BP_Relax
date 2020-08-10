using Core;

namespace Interfaces
{
    public interface ILevelLoaderModeHandler
    {
        void OnLevelLoad(GameMode.GameModes mode);
    }
}