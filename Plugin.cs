using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EOTechFix.Patches;
using HarmonyLib;
using SPT.Reflection;
using System.Reflection;

namespace EOTechFix
{
    [BepInPlugin("com.matsix.eotechfix", "EOTechFix-matsix", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {

        public static ManualLogSource MyLog;

        private void Awake()
        {
            MyLog = Logger;
            Logger.LogInfo("EOTech fix loaded!");

            new EOTechFixer().Enable();
        }
    }
}
