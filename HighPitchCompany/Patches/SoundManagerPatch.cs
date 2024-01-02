using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using GameNetcodeStuff;

namespace HighPitchCompany.Patches
{
    [HarmonyPatch(typeof(SoundManager))]
    internal class SoundManagerPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void highPitchPatch(ref float[] ___playerVoicePitchTargets, ref float[] ___playerVoicePitches)
        {
            ___playerVoicePitches = new float[4] { 3f, 3f, 3f, 3f };
            ___playerVoicePitchTargets = new float[4] { 3f, 3f, 3f, 3f };
        }
    }
}
