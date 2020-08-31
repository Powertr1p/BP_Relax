using UnityEngine;

namespace UI
{
   public class MoreGamesButton : MonoBehaviour
   {
      private string[] _appLinks =
      {
         "details?id=com.Bezrukov.TearIt", 
         "details?id=com.IJunior.TrafficGame",
         "details?id=com.IJunior.FindAPairLanguage"
      };
      
      public void OpenStore()
      {
         Application.OpenURL($"market://{_appLinks[Random.Range(0, _appLinks.Length)]}");
      }
   }
}
