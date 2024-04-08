using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using YaHochuKakat.Patches;

namespace YaHochuKakat
{
    [BepInPlugin(ModInfo.GUID, ModInfo.NAME, ModInfo.VERSION)]
    internal class YaHochuKakat : BaseUnityPlugin
    {
        private Harmony _harmony = new Harmony(ModInfo.GUID);

        private ManualLogSource _logger;

        private const string BUNDLE_NAME = "i_want_to_poop";

        internal static AudioClip[] NewSFX;

        private void Awake()
        {
            _logger = BepInEx.Logging.Logger.CreateLogSource(ModInfo.GUID);

            _logger.LogInfo($"{ModInfo.NAME} is loading.");

            string dllPath = Info.Location;
            //string dllName = Assembly.GetAssembly(typeof(YaHochuKakat)).ToString();
            string dllName = "YaHochuKakat.dll";
            string folderPath = dllPath.TrimEnd(dllName.ToCharArray());
            string fullPathToBundle = folderPath + BUNDLE_NAME;

            AssetBundle bundle = AssetBundle.LoadFromFile(fullPathToBundle);

            bool isBundleFoundAndLoaded = bundle != null;

            if (isBundleFoundAndLoaded)
            {
                NewSFX = bundle.LoadAllAssets<AudioClip>();
                _harmony.PatchAll(typeof(HoarderBugPatch));
                _logger.LogInfo($"{ModInfo.NAME} is successfully loaded.");
            }
            else
            {
                _logger.LogError("Failed to load asset bundle!");
            }
        }
    }
}
