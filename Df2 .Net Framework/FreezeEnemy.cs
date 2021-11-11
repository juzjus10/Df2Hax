using UnityEngine;
using HarmonyLib;

namespace Df2Hax
{
    public class FreezeEnemy : MonoBehaviour
    {
       
        [HarmonyPrefix]
        public static void Freeze(ref bool __result)
        {
            __result =  false;
        }
    }
}
