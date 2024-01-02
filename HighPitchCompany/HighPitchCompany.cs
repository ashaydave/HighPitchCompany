using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using HighPitchCompany.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighPitchCompany
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class HighPitchCompany : BaseUnityPlugin
    {
        private const string modGUID = "Ashay.HighPitchCompany";
        private const string modName = "High Pitch Company";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static HighPitchCompany Instance;

        internal ManualLogSource manualLogSource;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            manualLogSource = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            manualLogSource.LogInfo("High Pitch Company Loaded");
            harmony.PatchAll(typeof(HighPitchCompany));
            harmony.PatchAll(typeof(SoundManagerPatch));
        }
    }
}
