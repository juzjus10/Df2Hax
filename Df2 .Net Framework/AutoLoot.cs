using System;
using System.Collections;
using UnityEngine;

namespace Df2Hax
{
    class AutoLoot : MonoBehaviour
    {
        public CF_3d58f30ae6797e48debc9164e4554f0b4f328c99_Corpsefuscated[] loot;
        public GameObject localPlayer;
        public void Start()
        {
            StartCoroutine(UpdateEntities(0));
            loot = FindObjectsOfType<CF_3d58f30ae6797e48debc9164e4554f0b4f328c99_Corpsefuscated>();
            localPlayer = GameObject.Find("Player");
        }

        public void OnGUI()
        {
            if (Event.current.type != EventType.Repaint)
                return;

            foreach (var loots in loot)
            {
                GUIStyle style = new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter
                };
                style.normal.textColor = Color.yellow;

                Vector3 w2s = Camera.main.WorldToScreenPoint(loots.transform.position);

                if (w2s.z > 0f)
                {
                    if (loots.lootID > -1 && loots.isEnabled)
                    {
                        GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), loots.name + " [ LootID: " + loots.lootID.ToString() + "  ]", style);//Name Esp

                    }
                }
              
            }
        }
        public void Update()
        {
            foreach (var loots in loot)
            {
                if (loots.lootID > -1 && loots.isEnabled)
                {
                    int ctr = 0;

                    if (Input.GetKeyDown(KeyCode.BackQuote))
                    {                    
                        loots.CF_78b50f9c054bbbec3720d3058eb274442b4bc02a_Corpsefuscated();
                        Console.WriteLine("Loot:"+loots.name + "ID:" + ctr);
                        ctr++;
                        continue;
                    }
                }
                  
            }
           
        }

        public IEnumerator UpdateEntities(float time)
        {
            yield return new WaitForSeconds(time);
            try
            {
                loot = FindObjectsOfType<CF_3d58f30ae6797e48debc9164e4554f0b4f328c99_Corpsefuscated>();
            }
            catch
            {
                Debug.Log("No Loots");
            }

            StartCoroutine(UpdateEntities(2));
        }
    }
}
