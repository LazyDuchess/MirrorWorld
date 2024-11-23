using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reptile;
using HarmonyLib;
using UnityEngine;

namespace MirrorWorld.Patches
{
    [HarmonyPatch(typeof(Mapcontroller))]
    internal class MapcontrollerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Mapcontroller.Awake))]
        private static void Awake_Postfix(Mapcontroller __instance)
        {
            CameraMirrorer.AddToCamera(__instance.Camera);
        }
    }
}
