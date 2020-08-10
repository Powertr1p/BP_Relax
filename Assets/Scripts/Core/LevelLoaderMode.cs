using Interfaces;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LevelLoaderMode
    {
        public static void Load(string sceneName, GameMode.GameModes mode)
        {
            UnityAction<Scene, Scene> changeHandler = null;

            changeHandler = (from, to) =>
            {
                if (to.name == sceneName)
                {
                    SceneManager.activeSceneChanged -= changeHandler;

                    foreach (var rootObject in to.GetRootGameObjects())
                    foreach (var handler in rootObject.GetComponentsInChildren<ILevelLoaderModeHandler>())
                        handler.OnLevelLoad(mode);
                }
            };
            
            SceneManager.activeSceneChanged += changeHandler;
            SceneManager.LoadScene(sceneName);
        }
    }
}