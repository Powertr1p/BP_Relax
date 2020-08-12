using Interfaces;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LevelLoaderMode
    {
        public static void Load(string sceneName, GameModes mode)
        {
            void ChangeHandler(Scene @from, Scene to)
            {
                if (to.name != sceneName) return;

                SceneManager.activeSceneChanged -= ChangeHandler;

                foreach (var rootObject in to.GetRootGameObjects())
                foreach (var handler in rootObject.GetComponentsInChildren<ILevelLoaderModeHandler>())
                    handler.OnLevelLoad(mode);
            }

            SceneManager.activeSceneChanged += ChangeHandler;
            SceneManager.LoadScene(sceneName);
        }
    }
}