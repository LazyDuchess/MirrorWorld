using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Reptile;

namespace MirrorWorld.Patches
{
    [HarmonyPatch(typeof(GameplayCamera))]
    internal static class GameplayCameraPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(GameplayCamera.CalculateOrbitInput))]
        private static bool CalculateOrbitInput_Prefix(float camXInput, float camYInput, GameplayCamera __instance)
        {
            __instance.orbitInput = __instance.CalculateNormalOrbitInput(-camXInput, camYInput);
            return false;
        }
    }
}
