using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LoadObjectExample.Component
{
    internal class ObjectToLoad : MonoBehaviour
    {
        void Awake()
        {
            ExampleBaseClass.mls.LogInfo("Object example loaded.");
        }

        void OnDestroy()
        {
            ExampleBaseClass.mls.LogInfo("Object example destroyed.");
        }

        public void DoSomething()
        {
            ExampleBaseClass.mls.LogInfo("The example object has something to say :)");
        }

        public void Update()
        {
            ExampleBaseClass.mls.LogInfo("Update function called automatically by the game.");
        }
    }
}
