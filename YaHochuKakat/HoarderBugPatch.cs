using HarmonyLib;
using UnityEngine;

namespace YaHochuKakat.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class HoarderBugPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void OverrideSFX(ref AudioClip[] ___chitterSFX)
        {
            AudioClip[] newSFX = YaHochuKakat.NewSFX;
            ___chitterSFX = newSFX;
        }
    }
}
