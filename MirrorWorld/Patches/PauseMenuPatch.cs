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
    [HarmonyPatch(typeof(PauseMenu))]
    internal class PauseMenuPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(PauseMenu.UpdateMapController))]
        private static bool UpdateMapController_Prefix(PauseMenu __instance)
        {
            __instance.mapControllerInstance.CameraZoom += __instance.gameInput.GetAxis(67, 0) * Time.deltaTime;
            if (__instance.dragCamera || __instance.gameInput.IsPlayerControllerJoystick(0))
            {
                __instance.mapControllerInstance.CameraRotateYOffset += __instance.gameInput.GetAxis(13, 0) * 80f * Time.deltaTime;
                __instance.mapControllerInstance.CameraRotateXOffset -= __instance.gameInput.GetAxis(14, 0) * 80f * Time.deltaTime;
            }
            return false;
        }
    }
}
