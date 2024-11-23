using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using Reptile;

namespace MirrorWorld.Patches
{
    [HarmonyPatch(typeof(PlayerPhoneCameras))]
    internal static class PlayerPhoneCamerasPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(PlayerPhoneCameras.Awake))]
        private static void Awake_Postfix(PlayerPhoneCameras __instance)
        {
            var cams = __instance.GetComponentsInChildren<Camera>(true);
            foreach (var cam in cams)
            {
                CameraMirrorer.AddToCamera(cam);
            }
        }
    }
}
