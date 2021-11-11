using System.Reflection;
using UnityEngine;

namespace Df2Hax
{
    class Godmode : MonoBehaviour
    {
        // Search "Player" 
        public CF_c77af03189c43ff622c097f6e8b45f8247063a74_Corpsefuscated zombieattack;
        public CF_27adf9cf39c29c18581b4fc22cd6caf47e30c8da_Corpsefuscated enabled;

        public void Start()
        {
            zombieattack = FindObjectOfType<CF_c77af03189c43ff622c097f6e8b45f8247063a74_Corpsefuscated>();
            enabled = new CF_27adf9cf39c29c18581b4fc22cd6caf47e30c8da_Corpsefuscated(true);
        }

        public void Update()
        {
            if (Hacks.godmode)
            {
                enabled = new CF_27adf9cf39c29c18581b4fc22cd6caf47e30c8da_Corpsefuscated(true);
                GodmodeON(enabled);
            }
            else
            {
                enabled = new CF_27adf9cf39c29c18581b4fc22cd6caf47e30c8da_Corpsefuscated(false);
                GodmodeON(enabled);
            }
        }
        public void GodmodeON(bool enable)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            try
            {
                var zombieattackField = typeof(CF_c77af03189c43ff622c097f6e8b45f8247063a74_Corpsefuscated).GetField("CF_0be0a6e40f78991c9ad9b5d4ee9e2484f754eaa1_Corpsefuscated", bindFlags);
                zombieattackField.SetValue(zombieattack, enabled);
            } catch
            {
                UnityEngine.Debug.Log("God Mode Failed");
            }
            
        }
    }
}
