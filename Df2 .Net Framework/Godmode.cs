using System.Reflection;
using UnityEngine;

namespace Df2Hax
{
    class Godmode : MonoBehaviour
    {
        // Search "Player" 
        public CF_03b0bba26a32ca13418fcf3653b5e339377e0b79_Corpsefuscated zombieattack;
        public CF_0fb16d023ebc3703eaa91b26e6a3f0272e3a7722_Corpsefuscated enabled;

        public void Start()
        {
            zombieattack = FindObjectOfType<CF_03b0bba26a32ca13418fcf3653b5e339377e0b79_Corpsefuscated>();
            enabled = new CF_0fb16d023ebc3703eaa91b26e6a3f0272e3a7722_Corpsefuscated(true);
        }

        public void Update()
        {
            if (Hacks.godmode)
            {
                enabled = new CF_0fb16d023ebc3703eaa91b26e6a3f0272e3a7722_Corpsefuscated(true);
                GodmodeON(enabled);
            }
            else
            {
                enabled = new CF_0fb16d023ebc3703eaa91b26e6a3f0272e3a7722_Corpsefuscated(false);
                GodmodeON(enabled);
            }
        }
        public void GodmodeON(bool enable)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            try
            {
                var zombieattackField = typeof(CF_03b0bba26a32ca13418fcf3653b5e339377e0b79_Corpsefuscated).GetField("CF_a4b4a1245d3e373ae48063453c12794d7901ecc0_Corpsefuscated", bindFlags);
                zombieattackField.SetValue(zombieattack, enabled);
            } catch
            {
                UnityEngine.Debug.Log("God Mode Failed");
            }
            
        }
    }
}
