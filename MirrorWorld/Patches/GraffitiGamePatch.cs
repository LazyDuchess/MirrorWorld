using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Reptile;
using UnityEngine;

namespace MirrorWorld.Patches
{
    [HarmonyPatch(typeof(GraffitiGame))]
    internal static class GraffitiGamePatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(GraffitiGame.TargetingUpdate))]
        private static void TargetingUpdate_Prefix(GraffitiGame __instance)
        {
            __instance.aim = new Vector2(-__instance.aim.x, __instance.aim.y);
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(GraffitiGame.InitVisual))]
        private static void InitVisual_Postfix(GraffitiGame __instance)
        {
            var myCams = __instance.transform.GetComponentsInChildren<Camera>(true);
            foreach(var cam in myCams)
                CameraMirrorer.AddToCamera(cam);
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(GraffitiGame.SetState))]
        private static void SetState_Postfix(GraffitiGame __instance, GraffitiGame.GraffitiGameState setState)
        {
            if (setState == GraffitiGame.GraffitiGameState.MAIN_STATE) return;
            var gSpotCams = __instance.gSpot.transform.GetComponentsInChildren<Camera>(true);
            foreach (var cam in gSpotCams)
                CameraMirrorer.AddToCamera(cam);
        }
    }
}
