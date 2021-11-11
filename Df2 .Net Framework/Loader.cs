using UnityEngine;
namespace Df2Hax
{
    class Loader : MonoBehaviour
    {
        public static GameObject newGameObject;
        public static void Load()
        {
            newGameObject = new GameObject();
            DontDestroyOnLoad(newGameObject);
            newGameObject.AddComponent<Hacks>();
            newGameObject.AddComponent<Godmode>();
            newGameObject.AddComponent<FreezeEnemy>();
            //newGameObject.AddComponent<AutoLoot>();
            //var harmony = new Harmony("com.juzjus10.claour.df2hax");
            //var originalUpdate = AccessTools.Method(typeof(CF_9e90c461fc43d15efa18b583678e27c68fa10e6c_Corpsefuscated), "CF_7bc19a5b198cecad80435c2133c188b619f0d5c9_Corpsefuscated"); 
            //var postUpdate = AccessTools.Method(typeof(FreezeEnemy), "Freeze");
            //harmony.Patch(originalUpdate, postfix: new HarmonyMethod(postUpdate));
        }

        public static void Unload()
        {
            Destroy(newGameObject);
        }
    }
}