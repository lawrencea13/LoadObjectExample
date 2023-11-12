using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LoadObjectExample.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LoadObjectExample
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ExampleBaseClass : BaseUnityPlugin
    {
        private const string modGUID = "Posiedon.ExampleObjectLoader";
        private const string modName = "Example Object Loader";
        private const string modVersion = "1.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        public static ManualLogSource mls;

        private static ObjectToLoad myLoadedObject;

        void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource("Example Object Loader");
            mls.LogInfo("Loaded Example. Patching.");
            harmony.PatchAll(typeof(ExampleBaseClass));
            mls = Logger;

            // probably come up with better name
            var gameObject = new UnityEngine.GameObject("MyGameObject");
            // these 2 lines are important
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.hideFlags = HideFlags.HideAndDontSave;

            // add component and create local reference
            gameObject.AddComponent<ObjectToLoad>();
            myLoadedObject = (ObjectToLoad)gameObject.GetComponent("ObjectToLoad");

            myLoadedObject.DoSomething();
        }

    }
}
