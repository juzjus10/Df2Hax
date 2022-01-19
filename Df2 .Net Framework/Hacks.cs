using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
//using BepInEx;


namespace Df2Hax
{
    // [BepInPlugin(guid,pname, version)]
    // class BepInExLoader:BaseUnityPlugin
    //{
    //    public const string guid = "juzjus10.df2.hax";
    //    public const string pname = "Df2Hax";
    //    public const string version = "2.0.0.0";

    //}

    class Hacks : MonoBehaviour
    {

        public bool toggleMenu = true;
        public bool esp = false;
        public bool mobVac = false;
        public bool aimbot = false;
        public static bool godmode = false;
        public float gamespeed = 1f;
        public float fov = 60f;
        public float mobDistance = 1f;


        public Rigidbody rbody;
        public CF_d827a7148ec34455d8ac2cdd5c9e72a0ac20ec4c_Corpsefuscated[] zombie;
        public GameObject localPlayer;
        public GameObject enemy;
        public CF_1a91fe8c9c9b331adfbcea7c04e0b8e1d54e6e11_Corpsefuscated cameraRig;
       // public CF_4ce5915a67e976333f555f231b028fd974eaeb23_Corpsefuscated melee;
        //public CF_b97b74cfde6c66841c7052617061ff78b12b21aa_Corpsefuscated weapon;
        //  public CF_fbdbab9b6307212633f025c0f695b3c0183dbf38_Corpsefuscated damage; 


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        public void Awake()
        {
           
            StartCoroutine(UpdateEntities(0));
            rbody = GetComponent<Rigidbody>();
            localPlayer = GameObject.Find("Player");
            enemy = GameObject.Find("Enemy");
            cameraRig = FindObjectOfType<CF_1a91fe8c9c9b331adfbcea7c04e0b8e1d54e6e11_Corpsefuscated>();
            //weapon = FindObjectOfType<CF_b97b74cfde6c66841c7052617061ff78b12b21aa_Corpsefuscated>();
            //  damage = FindObjectOfType<CF_fbdbab9b6307212633f025c0f695b3c0183dbf38_Corpsefuscated>();


        }

        public void OnGUI()
        {
            if (toggleMenu)
            {
                GUI.Box(new Rect(50f, 50f, 250f, 415f), "DEAD FRONTIER 2 MULTI HACK \n by Juzz");
                esp = GUI.Toggle(new Rect(100, 100, 100, 17), esp, "Simple ESP");
                mobVac = GUI.Toggle(new Rect(100, 130, 100, 17), mobVac, "Mob Vacuum");
                GUI.Label(new Rect(100, 160, 100, 17), "Mob Distance");
                mobDistance = GUI.HorizontalSlider(new Rect(100, 190, 100, 17), mobDistance, 1f, 30f);
               GUI.Label(new Rect(100, 220, 100, 17), "Speed Hack");
                gamespeed = GUI.HorizontalSlider(new Rect(100, 250, 100, 17), gamespeed, 1f, 10f);
                GUI.Label(new Rect(100, 280, 100, 17), "FOV");
                fov = GUI.HorizontalSlider(new Rect(100, 310, 100, 17), fov, 50, 200f);
                aimbot = GUI.Toggle(new Rect(100, 340, 100, 17), aimbot, "Aimbot");
                godmode = GUI.Toggle(new Rect(100, 370, 100, 17), godmode, "Godmode");
                changeFOV();
            }

            if (esp)
            {
                foreach (var zombs in zombie)
                {
                    GUIStyle style = new GUIStyle
                    {
                        alignment = TextAnchor.MiddleCenter
                    };
                    style.normal.textColor = Color.white;

                    Vector3 w2s = Camera.main.WorldToScreenPoint(zombs.transform.position);

                    if (w2s.z > 0f)
                    {

                        Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(w2s.x, (float)Screen.height - w2s.y), Color.red, 2f);
                        GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), zombs.name + " [ HP: " + zombs.health + " ]", style);//Name Esp
                    }


                }
            }

        }
        public void Update()
        {
         
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                toggleMenu = !toggleMenu;
            }

            //var niggar = zombie.Length;
            Vector2 target = Vector2.zero;
            float minDist = 99999f;
            try
            {
                foreach (var zombs in zombie)
                {

                    Transform[] allChildren = zombs.transform.GetComponentsInChildren<Transform>();
                    //Dumb AI
                    zombs.CF_f9f42368e710720c7744a0be70f511546854ef44_Corpsefuscated = 1;
                   
                    // Autokill Zombies SO fuckin risky 
                    //if (Input.GetKey(KeyCode.V))
                    //{
                    //    if (zombs.health > 0)
                    //    {
                    //        zombs.CF_063207babd8b7f693c091dd0da6e760050b3601f_Corpsefuscated(Vector3.zero, localPlayer, null, 1, 1, 1, 1, 1, null, false, true, (int)zombs.health, false);
                    //        break;
                    //    }
                        
                    //}
                    

                    if (mobVac)
                    {
                        try
                        {
                            rbody.constraints = RigidbodyConstraints.FreezePosition;
                            zombs.transform.position = new Vector3(this.localPlayer.transform.position.x, this.localPlayer.transform.position.y, this.localPlayer.transform.position.z + mobDistance);
                        }
                        catch
                        {
                            Debug.Log("Mob Vac Fail");
                        }

                    }
                    foreach (Transform child in allChildren)
                    {
                        if (child.name == "Fire")
                        {
                            child.gameObject.SetActive(false);
                        }
                        if (child.name == "Flies")
                        {
                            child.gameObject.SetActive(false);
                        }
                        if (child.name == "Gas")
                        {
                            child.gameObject.SetActive(false);
                        }


                        if (aimbot)
                        {
                            if (child.name.Contains("Head"))
                            {

                                var w2s = Camera.main.WorldToScreenPoint(child.transform.position);

                                if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 150f)
                                    continue;

                                float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));

                                if (distance < minDist)
                                {
                                    minDist = distance;
                                    target = new Vector2(w2s.x, Screen.height - w2s.y);
                                }
                            }
                        }
                    }

                }

                if (target != Vector2.zero)
                {
                    double distX = target.x - Screen.width / 2f;
                    double distY = target.y - Screen.height / 2f;
                    if (Input.GetKey(KeyCode.C))
                    {
                        distX /= 3;
                        distY /= 3;
                        mouse_event(0x0001, (int)distX, (int)distY, 0, 0);
                    }

                }
            } catch
            {
                Debug.Log("Failed to update zombie");
            }
            
            Time.timeScale = gamespeed;

        }


        public void changeFOV()
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            try
            {
                var cameraRigField = typeof(CF_1a91fe8c9c9b331adfbcea7c04e0b8e1d54e6e11_Corpsefuscated).GetField("CF_bd53525239991bcaa3c3093ccb6cc24eb052774e_Corpsefuscated", bindFlags);
                cameraRigField.SetValue(cameraRig, fov);
            } catch
            {
                UnityEngine.Debug.Log("FOV Changer Fail");
            }
           

        }



        public IEnumerator UpdateEntities(float time)
        {
            yield return new WaitForSeconds(time);
            try
            {
                zombie = FindObjectsOfType<CF_d827a7148ec34455d8ac2cdd5c9e72a0ac20ec4c_Corpsefuscated>();              
            } catch
            {
                UnityEngine.Debug.Log("No Entity");
            }
            
            StartCoroutine(UpdateEntities(2));
        }


    }
}
