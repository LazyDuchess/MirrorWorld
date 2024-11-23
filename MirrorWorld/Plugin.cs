using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.IO;

namespace MirrorWorld
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance = null;
        public Material MirrorMaterial = null;
        private void Awake()
        {
            // Plugin startup logic
            Instance = this;
            var bundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Info.Location), "shader"));
            MirrorMaterial = bundle.LoadAsset<Material>("MirrorMaterial");
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
