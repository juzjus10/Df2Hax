using UnityEngine;
using System.Reflection;
using System.Collections;

namespace Df2Hax
{
    class Weapon : MonoBehaviour
    {
        public CF_a13aad62d5897485736e0b370ec6ace302eb298d_Corpsefuscated[] weapon;
        public void Start()
        {
            weapon = FindObjectsOfType<CF_a13aad62d5897485736e0b370ec6ace302eb298d_Corpsefuscated>();
        }

        public void Update()
        {
            foreach (var weapons in weapon)
            {
                
            }
        }

        public void changeValue()
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            try
            {
                var speed = typeof(CF_a13aad62d5897485736e0b370ec6ace302eb298d_Corpsefuscated).GetField("CF_149af7eaf9e19e6a8b4b7c7834297b44311f7915_Corpsefuscated", bindFlags);
                IEnumerable items = speed as IEnumerable;

                //foreach (var i in items)
                //{
                //    i.SetValue(speed, 0.01f);
                //}
                
            }
            catch
            {
                UnityEngine.Debug.Log("Weapon Mod Failed");
            }
        }
    }
}
