using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Reptile;

namespace MirrorWorld.Patches
{
    [HarmonyPatch(typeof(UserInputHandler))]
    internal static class UserInputHandlerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(UserInputHandler.PollInputs))]
        private static void PollInputs_Postfix(ref UserInputHandler.InputBuffer inputBuffer, ref UserInputHandler.InputBuffer __result)
        {
            inputBuffer.moveAxisX = -inputBuffer.moveAxisX;
            __result = inputBuffer;
        }
    }
}
