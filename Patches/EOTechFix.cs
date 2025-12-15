using EFT;
using EFT.UI.Matchmaker;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EOTechFix.Patches
{
    internal class EOTechFixer : ModulePatch
    {
        public static bool cleanerRan = false;

        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(CollimatorSight), nameof(CollimatorSight.OnEnable));
        }

        [PatchPostfix]
        static void Postfix(CollimatorSight __instance)
        {
            if (!__instance.CollimatorMaterial.HasProperty("_MarkScale"))
                return;
            // Mark scale pulls the red dot/holo closer to the lens the higher it is, which makes it shift around when looking
            // as this value decreases it gets pushed further away from the lens, gets smaller, but it stops shifting around
            float markScale = __instance.CollimatorMaterial.GetFloat("_MarkScale");
            if (markScale != 1)
            {
                __instance.CollimatorMaterial.SetFloat("_MarkScale", 1f);
                // Mark shift increases the size of the dot/holo the smaller the value, the more negative it gets the smaller it gets
                float newMarkShift = 150 + ((1 - markScale) * 125);
                __instance.CollimatorMaterial.SetVector("_MarkShift", new Vector4(0, newMarkShift * -1, 0, 0));
            }
        }
    }
}
