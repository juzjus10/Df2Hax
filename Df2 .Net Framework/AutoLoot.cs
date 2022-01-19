using System;
using System.Collections;
using UnityEngine;

namespace Df2Hax
{
    class AutoLoot : MonoBehaviour
    {
        public CF_7e14d3a24ad036e7982c95490d4cdf217ce0821c_Corpsefuscated[] loot;
        public GameObject localPlayer;
        public void Start()
        {
            StartCoroutine(UpdateEntities(0));
            loot = FindObjectsOfType<CF_7e14d3a24ad036e7982c95490d4cdf217ce0821c_Corpsefuscated>();
            localPlayer = GameObject.Find("Player");
        }

        public void OnGUI()
        {
             try
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
            } catch (Exception e)
            {
                Console.WriteLine("Cant find loots " + e);
            }
            
        }
        public void Update()
        {
            try
            {
                foreach (var loots in loot)
                {
                    if (loots.lootID > -1 && loots.isEnabled)
                    {
                        int ctr = 0;

                        if (Input.GetKeyDown(KeyCode.BackQuote))
                        {
                            loots.CF_f81a595255ce328e17839e5e031d99f84ba492ba_Corpsefuscated();
                            Console.WriteLine("Loot:" + loots.name + "ID:" + ctr);
                            ctr++;
                            Console.WriteLine(ctr);
                            break;
                        }
                    }

                }
            } catch (Exception e)
            {
                Console.WriteLine("Unable to get loots " + e);
            }
           
           
        }

        public IEnumerator UpdateEntities(float time)
        {
            yield return new WaitForSeconds(time);
            try
            {
                loot = FindObjectsOfType<CF_7e14d3a24ad036e7982c95490d4cdf217ce0821c_Corpsefuscated>();
            }
            catch
            {
                Debug.Log("No Loots");
            }

            StartCoroutine(UpdateEntities(2));
        }
    }
}
