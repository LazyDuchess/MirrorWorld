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
    [HarmonyPatch(typeof(WorldHandler))]
    internal static class WorldHandlerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(WorldHandler.SetCurrentCamera))]
        private static void SetCurrentCamera_Postfix(Camera camera)
        {
            CameraMirrorer.AddToCamera(camera);
        }
    }
}
