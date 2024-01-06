using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using GameNetcodeStuff;

namespace HighPitchCompany.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        static void playerControllerBPatch(PlayerControllerB playerControllerB)
        {
            SoundManager.Instance.playerVoicePitchTargets[playerControllerB.playerClientId] = 3f;
        }
    }

    [HarmonyPatch(typeof(SoundManager))]
    internal class SoundManagerPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void highPitchPatch(PlayerControllerB playerControllerB, ref float[] ___playerVoicePitchTargets, ref float[] ___playerVoicePitches)
        {
            ___playerVoicePitches = new float[4] { 3f, 3f, 3f, 3f };
            ___playerVoicePitchTargets = new float[4] { 3f, 3f, 3f, 3f };

        }
    }

    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        [HarmonyPatch("UpdatePlayerVoiceEffects")]
        [HarmonyPostfix]
        static void updatePlayerVoiceEffectsPatch(PlayerControllerB playerControllerB)
        {
            SoundManager.Instance.playerVoicePitchTargets[playerControllerB.playerClientId] = 3f;
            SoundManager.Instance.SetPlayerPitch(3f, (int)playerControllerB.playerClientId);
        }
    }

}
