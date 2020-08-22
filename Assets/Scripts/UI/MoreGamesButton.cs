using UnityEngine;

namespace UI
{
   public class MoreGamesButton : MonoBehaviour
   {
      public void OpenStore()
      {
         Application.OpenURL("market://details?id=5525032069872992445");
      }
   }
}
